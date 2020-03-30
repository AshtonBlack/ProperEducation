using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace HomeWork3._3
{
    class Program
    {
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static void Main(string[] args)
        {
            try
            {
                socket.Connect("127.0.0.1", 50000);
            }
            catch
            {
                Console.WriteLine("Невозможно подключиться");
                Console.ReadKey();
                Process.GetCurrentProcess().Kill();
            }
            Console.WriteLine("Что скажешь?");
            while (true)
            {
                string messageout = Console.ReadLine();
                byte[] bufferout = Encoding.UTF8.GetBytes(messageout);
                byte[] bufferin = new byte[1024];
                socket.Send(bufferout);
                socket.Receive(bufferin);
                string messagein = Encoding.UTF8.GetString(bufferin);
                Console.WriteLine(messagein);
            }            
        }
    }
}