using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashControlsWinFormsProto
{
    class Ping
    {
        public string Username { get; set; }
        public string ClientID { get; set; }
        public DateTime Timestamp { get; set; }
        public string UserPing { get; set; }

        public Ping(string username, string clientID, DateTime timestamp, string ping)
        {
            Username = username;
            ClientID = clientID;
            Timestamp = timestamp;
            UserPing = ping;
        }

        public override string ToString()
        {
            return Timestamp.ToLocalTime().Hour + ":" + Timestamp.ToLocalTime().Minute + ":" + Timestamp.ToLocalTime().Second + " " + Username + ": " + UserPing;
        }
    }
}
