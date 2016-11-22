using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TanksClient_demo
{
    public static class Input
    {
        public static void StartListening(Action<string> callback)
        {
            try
            {
                // Create the listener providing the IP Address and the port to listen on.
                var listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7000);
                listener.Start();

                // Listen in an endless loop. 
                while (true)
                {
                    // We will store the textual representation of the bytes we receive. 
                    string value;

                    // Accept the sender and take message as a stream. 
                    using (var networkStream = listener.AcceptTcpClient().GetStream())
                    {
                        // Create a memory stream to copy the message. 
                        using (var memoryStream = new MemoryStream())
                        {
                            // Copies the whole message to memory stream. No need to handle end of transmission
                            // or buffers manually. 
                            networkStream.CopyTo(memoryStream);

                            // TODO check encoding
                            // Convert bytes to text. 
                            value = Encoding.UTF8.GetString(memoryStream.ToArray());
                        }
                    }

                    // Call an external function (void) given. 
                    callback(value);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}