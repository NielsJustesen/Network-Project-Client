﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;


namespace NetworkProjectClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Klient";
            TCPClient c = new TCPClient("127.0.0.1", 5557);
        }
    }
}
