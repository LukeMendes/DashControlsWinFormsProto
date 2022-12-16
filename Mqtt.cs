using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace DashControlsWinFormsProto
{
    class Mqtt
    {
        public static string Username { get; set; }
        public static string ClientID { get; set; }
        public static List<Status> ConnectedUsers { get; set; }
        public static MqttClient Client { get; set; }

        static void Create(string[] args)
        {
            //Asks the user to specify a username
            Console.Write("Username: ");

            //Saves the user input as Username
            Username = Console.ReadLine();
            ConnectedUsers = new List<Status>();

            Console.WriteLine("Connecting...");

            try
            {
                //Creates the MqttClient for the specified broker url
                Client = new MqttClient("dashcontrols.cloud.shiftr.io");

                //Sets a unique ID for each client by using the username and a Guid
                ClientID = Username + "-" + Guid.NewGuid().ToString();

                //Connects to the mqtt broker using the clientID, login, password
                Client.Connect(ClientID, "dashcontrols", "bGqDYvcFnqJCOxtx");

                //Calls the Client_MqttMsgPublishReceived method whenever a new message is recieved (I think...)
                Client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;

                //Subscribes to all topics specified in the first array using the QOS level of the second array (Ignore the QOS stuff. For now level_exactly_once is fine.)
                Client.Subscribe(new string[] { "status", "ping" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

                Console.WriteLine("Connection established");

                Client.Publish("ping", null);

                string s = "";

                //Endless loop to keep the client running indefinitely
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("select an order");
                    string order = Console.ReadLine().ToLower();

                    //Removes the text from the Console
                    ClearCurrentConsoleLine();

                    if (order == "set")
                    {
                        bool eingabe;
                        do
                        {
                            Console.WriteLine("select your status");
                            s = Console.ReadLine();

                            //Removes the text from the Console
                            ClearCurrentConsoleLine();

                            if (s == "0" || s == "1" || s == "2")
                            {
                                StatusFestlegen(s);
                                eingabe = true;
                            }
                            else
                            {
                                eingabe = false;
                                Console.WriteLine("select \"0\", \"1\" or \"2\" for your status!");
                            }
                        } while (!eingabe);
                    }
                    else if (order == "show")
                    {
                        foreach (Status c in ConnectedUsers)
                        {
                            if (c.Color == "0")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            else if (c.Color == "1")
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else if (c.Color == "2")
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            Console.WriteLine(c);
                        }
                    }
                    else if (order == "reset")
                    {
                        StatusFestlegen("");
                    }
                    else
                    {
                        Console.WriteLine("select \"set\" or \"show\" for your order!");
                    }

                    //Lets the user input a text and saves it
                    //var text = Console.ReadLine();

                    //Removes the text from the Console
                    //ClearCurrentConsoleLine();

                    //Makes sure text is not null or empty
                    /*if (text is not null && text != "")
                    {
                        //Creates a new message object
                        var message = new Status(Username, ClientID, DateTime.UtcNow, s);

                        //Serializes the message object (turns it into a string)
                        var serializedMessage = JsonConvert.SerializeObject(message);

                        //Turns the serialized message into a byte array
                        var messageByteArray = Encoding.UTF8.GetBytes(serializedMessage);

                        //Publishes the messageByteArray to the specified topic
                        Client.Publish("status", messageByteArray);
                    }*/

                }
            }
            catch
            {
                Console.WriteLine("Connection failed");
            }

        }

        private static void StatusFestlegen(string s)
        {
            //Creates a new status object
            var status = new Status(Username, ClientID, DateTime.UtcNow, s);

            //Serializes the status object (turns it into a string)
            var serializedStatus = JsonConvert.SerializeObject(status);

            //Turns the serialized status into a byte array
            var statusByteArray = Encoding.UTF8.GetBytes(serializedStatus);

            //Publishes the statusByteArray to the specified topic
            Client.Publish("status", statusByteArray);
        }

        //Gets called when a new status is recieved
        static void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {

            if (e.Topic == "status")
            {
                //Gets the statusByteArray from the event
                var statusByteArray = e.Message;

                //Turns the byte array into a serialized status
                var serializedStatus = Encoding.UTF8.GetString(statusByteArray);

                //Deserializes the string into a status object

                var status = JsonConvert.DeserializeObject<Status>(serializedStatus);

                if (!ConnectedUsers.Contains(status))
                {
                    ConnectedUsers.Add(status);
                    ConnectedUsers.Sort();
                }
                else
                {
                    ConnectedUsers.Insert(ConnectedUsers.IndexOf(status), status);
                }

                if (status.Color == "0")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (status.Color == "1")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (status.Color == "2")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                //Writes the status to the console
                Console.WriteLine(status);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

        }

        //Clears the current line of the Console (Thanks to StackOverflow)
        public static void ClearCurrentConsoleLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
