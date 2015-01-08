// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//    http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Net;
using System.IO;
using Alachisoft.NCache.Runtime.Serialization;
using Alachisoft.NCache.Runtime.Serialization.IO;

namespace Alachisoft.NCache.Common.Net
{
	/// <summary> Abstract address. Used to identify members on a group to send messages to.
	/// Addresses are mostly generated by the bottom-most (transport) layers (e.g. UDP, TCP, LOOPBACK).
	/// Subclasses need to implement the following methods:
	/// <ul>
	/// <li>isMultiCastAddress()
	/// <li>equals()
	/// <li>hashCode()
	/// <li>compareTo()
	/// </ol>
	/// </summary>
	/// <author>  Bela Ban
	/// </author>
	[Serializable]
	public class Address : ICloneable, IComparable,ICompactSerializable
	{
		private IPAddress ip_addr;
		private int port;
		private byte[] additional_data;

		[NonSerialized]
		internal static bool resolve_dns = false;


		public Address() { }

		public Address(string i, int p)
		{
			try
			{
				ip_addr = Resolve(i);
			}
			catch (System.Exception e)
			{
				try
				{
					ip_addr = Resolve("127.0.0.1");
				}
				catch (System.Exception ex)
				{
				}
			}
			port = p;
		}

		public Address(IPAddress i, int p)
		{
			ip_addr = i; port = p;
		}

		public Address(int port)
		{
			try
			{
				ip_addr = Resolve(Dns.GetHostName());
				this.port = port;
			}
			catch (System.Exception e)
			{
			}
		}


		public IPAddress IpAddress { get { return ip_addr; } }
		public int Port { get { return port; } }
		public bool MulticastAddress { get { return ip_addr != null ? isMulticastAddress(ip_addr) : false; } }
		public byte[] AdditionalData
		{
			get { return additional_data; }
			set { this.additional_data = value; }
		}

		public static IPAddress Resolve(string addr)
		{
			IPAddress ip = null;
			try
			{
				ip = IPAddress.Parse(addr);
			}
			catch (Exception)
			{
				ip = DnsCache.ResolveName(addr);
			}
			return ip;
		}

		/// <summary> Establishes an order between 2 addresses. Assumes other contains non-null Address.
		/// Excludes channel_name from comparison.
		/// </summary>
		/// <returns> 0 for equality, value less than 0 if smaller, greater than 0 if greater.
		/// </returns>
		public int compare(Address other)
		{
			return CompareTo(other);
		}

		/// <summary> implements the java.lang.Comparable interface</summary>
		/// <seealso cref="java.lang.Comparable">
		/// </seealso>
		/// <param name="o">- the Object to be compared
		/// </param>
		/// <returns> a negative integer, zero, or a positive integer as this object is less than,
		/// equal to, or greater than the specified object.
		/// </returns>
		/// <exception cref=""> java.lang.ClassCastException - if the specified object's type prevents it
		/// from being compared to this Object.
		/// </exception>
		public int CompareTo(object o)
		{
			int h1 = 0, h2 = 0, rc;

            if ((o == null))
                return 1;

			Address other = o as Address;
            if (other == null) return 1;
			if (ip_addr == null)
				if (other.ip_addr == null)
					return port < other.port ? -1 : (port > other.port ? 1 : 0);
				else
					return -1;

            
			h1 = ip_addr.GetHashCode();
            if (other.ip_addr != null)
                h2 = other.ip_addr.GetHashCode();
			rc = h1 < h2 ? -1 : (h1 > h2 ? 1 : 0);
			return rc != 0 ? rc : (port < other.port ? -1 : (port > other.port ? 1 : 0));
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			return CompareTo(obj) == 0 ? true : false;
		}

		public override int GetHashCode()
		{
			int retval = ip_addr != null ? ip_addr.GetHashCode() + port : port;
			return retval;
		}


		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			if (ip_addr == null)
				sb.Append("<null>");
			else
			{
				if (isMulticastAddress(ip_addr))
					sb.Append(ip_addr.ToString());
				else
				{
					string host_name = null;
					if (resolve_dns)
					{
						host_name = DnsCache.ResolveAddress(ip_addr);
					}
					else
						host_name = ip_addr.ToString();
					appendShortName(host_name, sb);
				}
			}
			sb.Append(":" + port);

			return sb.ToString();
		}

		/// <summary> Input: "daddy.nms.fnc.fujitsu.com", output: "daddy". Appends result to string buffer 'sb'.</summary>
		/// <param name="hostname">The hostname in long form. Guaranteed not to be null
		/// </param>
		/// <param name="sb">The string buffer to which the result is to be appended
		/// </param>
		private void appendShortName(string hostname, System.Text.StringBuilder sb)
		{
			int index = hostname.IndexOf((System.Char)'.');

			if (hostname == null)
				return;
			if (index > 0 && !System.Char.IsDigit(hostname[0]))
				sb.Append(hostname.Substring(0, (index) - (0)));
			else
				sb.Append(hostname);
		}


		public object Clone()
		{
			Address ret = new Address(ip_addr.ToString(), port);
            if (additional_data != null)
            {
                 ret.additional_data = new byte[additional_data.Length];
                Array.Copy(additional_data, 0, ret.additional_data, 0, additional_data.Length);
            }
        
			return ret;
		}

		/// <summary>
		/// Converts an IP address in string to an equivalent byte array.
		/// </summary>
		/// <param name="ipaddr"></param>
		/// <returns>byte[] of IP address if ip is valid otherwise null</returns>
		static private byte[] ParseIPAddress(string ipaddr)
		{
			byte[] address = null;
			string[] mcast = ipaddr.Split(new char[] { '.' });

			if (mcast.Length == 4)
			{
				address = new byte[4];
				try
				{
					address[0] = Convert.ToByte(mcast[0]);
					address[1] = Convert.ToByte(mcast[1]);
					address[2] = Convert.ToByte(mcast[2]);
					address[3] = Convert.ToByte(mcast[3]);
				}
				catch (Exception) { return null; }
			}
			return address;
		}

		/// <summary>
		/// Checks if a specified string is a valid multi-cast ip-address.
		/// </summary>
		/// <param name="ipaddr"></param>
		/// <returns></returns>
		static public bool isMulticastAddress(string ipaddr)
		{
			try
			{
				return isMulticastAddress(ParseIPAddress(ipaddr));
			}
			catch (System.Exception)
			{
				return false;
			}

		}

		static public bool isMulticastAddress(System.Net.IPAddress ipAddr)
		{
			if (ipAddr != null)
			{
				string[] mcast = ipAddr.ToString().Split(new char[] { '.' });
				byte b1 = Convert.ToByte(mcast[0]);
				byte b2 = Convert.ToByte(mcast[1]);
				byte b3 = Convert.ToByte(mcast[2]);
				byte b4 = Convert.ToByte(mcast[3]);

				if ((b1 < 224) || (b1 > 240)) return false;
				if ((b1 == 224) && (b3 < 1)) return false;

				return true;
			}
			return false;
		}
		/// <summary>
		/// Checks if the specified IP address in byte[] array is a valid IP multicast Address.
		/// </summary>
		/// <param name="ipAddr"></param>
		/// <returns></returns>
		static private bool isMulticastAddress(byte[] ipAddr)
		{
			if (ipAddr != null && ipAddr.Length == 4)
			{
				if ((ipAddr[0] < 224) || (ipAddr[0] > 240)) return false;
				if ((ipAddr[0] == 224) && (ipAddr[2] < 1)) return false;

				return true;
			}
			return false;
		}

        public void DeserializeLocal(BinaryReader reader)
        {
            int bytesToRead = reader.ReadInt32();
            if (bytesToRead > 0)
            {
                byte[] ip = (byte[])reader.ReadBytes(bytesToRead);
                if (ip != null)
                {
                    try
                    {
                        ip_addr = new IPAddress(ip);
                    }
                    catch (Exception) { }
                }
            }

            port = reader.ReadInt32();
            
            bytesToRead = reader.ReadInt32();
            if (bytesToRead > 0)
                additional_data = reader.ReadBytes(bytesToRead);
        }

        public void SerializeLocal(BinaryWriter writer)
        {
            byte[] ip = ip_addr != null ? ParseIPAddress(ip_addr.ToString()) : null;
            
            if (ip != null)
            {
                writer.Write(ip.Length);
                writer.Write(ip);
            }
            else
                writer.Write(0);
            
            writer.Write(port);

            if (additional_data != null)
            {
                writer.Write(additional_data.Length);
                writer.Write(additional_data);
            }
            else
                writer.Write(0);
        }

        #region ICompactSerializable Members

        public void Deserialize(CompactReader reader)
        {

            byte[] ip = (byte[])reader.ReadObject();
            if (ip != null)
            {
                try
                {
                    ip_addr = new IPAddress(ip);
                }
                catch (Exception) { }
            }

            port = reader.ReadInt32();
            additional_data = (byte[])reader.ReadObject();

        }
        public void Serialize(CompactWriter writer)
        {
            byte[] ip = ip_addr != null ? ParseIPAddress(ip_addr.ToString()) : null;
            writer.WriteObject(ip);

            writer.Write(port);
            writer.WriteObject(additional_data);
        }

        #endregion

        public static Address ReadAddress(CompactReader reader)
        {
            byte isNull = reader.ReadByte();
            if (isNull == 1)
                return null;
            Address newAddr = new Address();
            newAddr.Deserialize(reader);
            return newAddr;
        }

        public static void WriteAddress(CompactWriter writer, Address addr)
        {
            byte isNull = 1;
            if (addr == null)
                writer.Write(isNull);
            else
            {
                isNull = 0;
                writer.Write(isNull);
                addr.Serialize(writer);
            }
            return;
        }

        public static Address Parse(string address)
        {
            string[] hostPort = address.Split(':');
            return new Address(hostPort[0], Convert.ToInt32(hostPort[1]));
        }
    }
}

namespace Alachisoft.NCache.Common
{
}
