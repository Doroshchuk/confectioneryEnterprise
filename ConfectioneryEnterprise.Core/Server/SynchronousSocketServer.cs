using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConfectioneryEnterprise.Core.Server
{
    /// <summary>
    /// Synchronous socket server listener
    /// </summary>
    public class SynchronousSocketServer
    {
        // Incoming Data from the client.  
        public static string Data = null;

        public static void StartListening()
        {
            // Data buffer for incoming Data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the   
            // host running the application.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and   
            // listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);

                // Maximum of connections
                listener.Listen(10);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Start server: OK");
                Console.ForegroundColor = ConsoleColor.White;

                // Start listening for connections
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    Console.ForegroundColor = ConsoleColor.White;

                    // Program is suspended while waiting for an incoming connection.  
                    Socket handler = listener.Accept();
                    Data = null;

                    // An incoming connection needs to be processed.  
                    while (true)
                    {
                        int bytesRec = handler.Receive(bytes);
                        Data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        // EOF end of file 
                        if (Data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                    }

                    // Show the Data on the console.  
                    Console.WriteLine("Text received : {0}", Data);

                    // Echo the Data back to the client.  
                    byte[] msg = Encoding.ASCII.GetBytes(Data);

                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }
    }
}
