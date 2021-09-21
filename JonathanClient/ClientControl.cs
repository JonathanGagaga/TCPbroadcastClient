using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;


namespace JonathanClient
{
    class ClientControl
    {
        private Socket clientSocket;

        public ClientControl()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }
        public void Connect(string ip, int port)
        {
            clientSocket.Connect(ip, port);
            Console.WriteLine("Succesful Connection");

            //Thread of client receiving server msgs
            Thread threadReceive = new Thread(Receive);
            threadReceive.IsBackground = true;
            threadReceive.Start();
        }

        private void Receive()
        {
            while (true)
            {
                try
                {
                    byte[] msg = new byte[1024];
                    int msgLen = clientSocket.Receive(msg);
                    Console.WriteLine("Server:" + Encoding.Default.GetString(msg, 0, msgLen));

                }
                catch
                {
                    Console.WriteLine("Server Rejects");
                    break;
                }
            }
        }
        public void Send()
        {
            Thread threadSend = new Thread(ReadAndSend);
            threadSend.Start();
        }
        public void ReadAndSend()
        {
            Console.WriteLine("Please type in what you want to send to the server or input 'quit' to exit.");

            string msg = Console.ReadLine();
            while (msg != "quit")
            {
                clientSocket.Send(Encoding.Default.GetBytes(msg));
                msg = Console.ReadLine();
            }
        }
    }
}
