using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace TanksClient_demo
{
    public static class Output
    {
        public static void SendToServer(string message)
        {
            try
            {
                // Using blocks automatically releases (IDisposable) resources after using. 
                using (var client = new TcpClient("127.0.0.1", 6000))
                {
                    // Convert text to get the binary representation.
                    var data = Encoding.UTF8.GetBytes(message);
                    // Write the binary data to the client stream. 
                    client.GetStream().Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}