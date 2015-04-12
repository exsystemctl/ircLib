using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ircLib
{
    public class ircLib
    {
        public static NetworkStream stream;
        public static StreamReader reader;
        public static StreamWriter writer;
        public static TcpClient irc;
        public static string channel;
        public static string inputLine;
        public static void Connect(string server, int port, string channel, string nick, string pass = "")
        {
            try
            {
                channel = "#" + channel;
                irc = new TcpClient(server, port);
                stream = irc.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);
                writer.WriteLine("PASS " + pass);
                writer.WriteLine("NICK " + nick);
                writer.Flush();
                writer.Flush();
                while (true)
                {
                    while ((inputLine = reader.ReadLine()) != null)
                    {
                        string[] splitInput = inputLine.Split(new Char[] { ' ' });
                        if (splitInput[0] == "PING")
                        {
                            string PongReply = splitInput[1];
                            writer.WriteLine("PONG " + PongReply);
                            writer.Flush();
                            continue;
                        }

                        switch (splitInput[1])
                        {
                            case "001":
                                string JoinString = "JOIN " + channel;
                                writer.WriteLine(JoinString);
                                writer.Flush();
                                break;
                            default:
                                break;
                        }
                    }
                    writer.Close();
                    reader.Close();
                    irc.Close();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void sendMessage(string message)
        {
            writer.WriteLine("PRIVMSG " + channel + " :" + message);
            writer.Flush();
        }

        public static string  getOutput()
        {
            return inputLine;
        }
    }
}
