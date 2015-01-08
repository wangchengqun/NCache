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

namespace Alachisoft.NGroups.Util
{
	/// <summary>
	/// Exception by MQueue when a thread tries to access a closed queue.
	/// <p><b>Author:</b> Chris Koiak</p>
	/// <p><b>Date:</b>  12/03/2003</p>
	/// </summary>
	internal class QueueClosedException : Exception 
	{
		/// <summary>
		/// Basic Exception
		/// </summary>
		public QueueClosedException() {}
		/// <summary>
		/// Exception with custom message
		/// </summary>
		/// <param name="msg">Message to display when exception is thrown</param>
		public QueueClosedException( String msg ) : base(msg){}

		/// <summary>
		/// Creates a String representation of the Exception
		/// </summary>
		/// <returns>A String representation of the Exception</returns>
		public String toString() 
		{
			if ( this.Message != null )
				return "QueueClosedException:" + this.Message;
			else
				return "QueueClosedException";
		}
	}

}
