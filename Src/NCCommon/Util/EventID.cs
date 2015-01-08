// Copyright (c) 2015 Alachisoft
// 
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
namespace Alachisoft.NCache.Common
{
    public class EventID
    {
        public const int CacheStart = 1000;
        public const int CacheStop = 1001;
        public const int CacheStartError = 1002;
        public const int CacheStopError = 1003;
        public const int ClientConnected = 1004;
        public const int ClientDisconnected = 1005;
        public const int NodeJoined = 1006;
        public const int NodeLeft = 1007;
        public const int StateTransferStart = 1008;
        public const int StateTransferStop = 1009;
        public const int StateTransferError = 1010;
        public const int UnhandledException = 1011;
        public const int LoginFailure = 1012;
        public const int ServiceStartFailure = 1013;
        public const int LoggingEnabled = 1014;
        public const int LoggingDisabled = 1015;
        public const int CacheSizeWarning = 1016;
        public const int GeneralError = 1017;
        public const int GeneralInformation = 1018;
        public const int ConfigurationError = 1019;
        public const int LicensingError = 1020;
        public const int BadClientFound = 1021;

        public static string EventText(int eventID)
        {
            string text = "";
            switch (eventID)
            {
                case EventID.CacheStart:
                    text = "Cache Start";
                    break;
                case EventID.CacheStop:
                    text = "Cache Stop";
                    break;
                case EventID.CacheStartError:
                    text = "Cache Start Error";
                    break;
                case EventID.CacheStopError:
                    text = "Cache Stop Error";
                    break;
                case EventID.ClientConnected:
                    text = "Client Connected";
                    break;
                case EventID.ClientDisconnected:
                    text = "Client Diconnected";
                    break;
                case EventID.NodeJoined:
                    text = "Node Joined";
                    break;
                case EventID.NodeLeft:
                    text = "Node Left";
                    break;
                case EventID.StateTransferStart:
                    text = "State Transfer Start";
                    break;
                case EventID.StateTransferStop:
                    text = "State Transfer Stop";
                    break;
                case EventID.StateTransferError:
                    text = "State Transfer Error";
                    break;
                case EventID.UnhandledException:
                    text = "Unhandled Exception";
                    break;
                case EventID.LoginFailure:
                    text = "Login Failure";
                    break;
                case EventID.ServiceStartFailure:
                    text = "Service Start Failure";
                    break;
                case EventID.CacheSizeWarning:
                    text = "Cache Size Warning";
                    break;
                case EventID.GeneralError:
                    text = "General Error";
                    break;
                case EventID.GeneralInformation:
                    text = "General Information";
                    break;
                case EventID.ConfigurationError:
                    text = "Configuration Error";
                    break;
                case EventID.LicensingError:
                    text = "Licensing Error";
                    break;
                case EventID.BadClientFound:
                    text = "Bad Client Found";
                    break;
                default:
                    text = "Unknown";
                    break;
            }

            return text;
        }
    }
}
