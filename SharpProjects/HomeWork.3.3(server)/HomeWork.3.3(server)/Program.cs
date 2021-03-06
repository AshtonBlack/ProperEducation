﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HomeWork._3._3_server_
{
    class Program
    {
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static int port = 50000;

        static void Main(string[] args)
        {
            EndPoint ep = new IPEndPoint(IPAddress.Any, port);
            socket.Bind(ep);
            List<Socket> clients = new List<Socket>();
            socket.Listen(5);
            socket.Blocking = false;
            bool flag = true;
            while (flag)
            {
                try
                {
                    clients.Add(socket.Accept());
                    Console.WriteLine("Somebody is here");
                }
                catch
                {
                    foreach (Socket client in clients)
                    {                        
                        try
                        {
                            byte[] buffer = new byte[1024];
                            client.Receive(buffer);
                            string message = Encoding.UTF8.GetString(buffer);
                            Console.WriteLine(message);
                            client.Send(Encoding.UTF8.GetBytes(message));
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }
    }
}