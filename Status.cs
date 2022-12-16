using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashControlsWinFormsProto
{
    class Status
    {
        public string Username { get; set; }
        public string ClientID { get; set; }
        public DateTime Timestamp { get; set; }
        public string Color { get; set; }

        public Status(string username, string clientID, DateTime timestamp, string status)
        {
            Username = username;
            ClientID = clientID;
            Timestamp = timestamp;
            Color = status;
        }

        public override string ToString()
        {
            return Timestamp.ToLocalTime().Hour + ":" + Timestamp.ToLocalTime().Minute + ":" + Timestamp.ToLocalTime().Second + " " + Username;
        }

        public override bool Equals(object obj)
        {
            return obj is Status status &&
                   ClientID == status.ClientID;
        }
    }
}
