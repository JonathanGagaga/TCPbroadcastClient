using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonathanClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientControl client = new ClientControl();
            client.Connect("127.0.0.1", 22); //local
            //client.Connect("121.4.189.114", 1234);// cloud computer
            client.Send();

            Console.ReadKey();
        }
    }
}
