using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using iRacing.CrewChief.Request;
using iRacing.CrewChief.Response;

namespace iRacing.CrewChief.Client.Socket
{
    abstract class SocketRequestHandler : IDisposable
    {
        private TcpClient _socket;
        private string _server = "127.0.0.1";
        private int _port = 13000;

        protected SocketRequestHandler()
        {
        }

        protected virtual string SendRequest(string requestMessage)
        {
            var responseData = Connect(_server, _port, requestMessage);
            return responseData;
        }

        private string Connect(String server, int port, String message)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                //Int32 port = port;
                TcpClient client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                //Console.WriteLine("Sent: {0}", message);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[1024*1024];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                /*     */
                //// Read the first batch of the TcpServer response bytes.
                //Int32 totalByteCount = stream.Read(data, 0, data.Length);
                //responseData = System.Text.Encoding.ASCII.GetString(data, 0, totalByteCount);
                
                /*  -------------------------   */
                int byteCount;
                int totalByteCount = 0;
                string dataString;
                StringBuilder sb = new StringBuilder();
                while ((byteCount = stream.Read(data, 0, data.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    dataString = System.Text.Encoding.ASCII.GetString(data, 0, byteCount);
                    sb.Append(dataString);
                    totalByteCount += byteCount;
                }
                responseData = sb.ToString();
                /*     */
                //Console.WriteLine("Received: {0} bytes", totalByteCount);

                // Close everything.
                stream.Close();
                client.Close();

                return responseData;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            return null;
            //Console.WriteLine("\n Press Enter to continue...");
            //Console.Read();
        }
        
        public void Dispose()
        {
            if ((null != _socket) && (_socket.Connected))
                _socket.Close();

            _socket = null;
        }

    }
}
