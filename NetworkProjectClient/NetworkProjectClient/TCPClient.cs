using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Net;
using System.IO;

namespace NetworkProjectClient
{
    class TCPClient
    {
        private TcpClient _client;

        private StreamWriter _sWriter;
        private StreamReader _sReader;
        private Boolean _isConnected;
        private String incommingData = null;


        public TCPClient(String ipaddress, int portNum)
        {
            _client = new TcpClient();
            _client.Connect(ipaddress, portNum);
            handleCommunication();

        }

        public void handleCommunication()
        {
            _sWriter = new StreamWriter(_client.GetStream(), Encoding.ASCII);
            _sReader = new StreamReader(_client.GetStream(), Encoding.ASCII);
            _isConnected = true;
            String sData = null;
            Console.Write("Write in your username>");
            sData = Console.ReadLine();
            _sWriter.WriteLine(sData);
            Console.Clear();
            Console.WriteLine("Choose your action:");
            Console.WriteLine("Move, to ecounter an enemy.");
            Console.WriteLine("Attack, to attack the enemy.");
            Console.WriteLine("Drink, to get health, when not in combat.");
            Console.WriteLine("Press any key to start.");
            Console.ReadKey();
            Console.Clear();
            while (_isConnected)
            {
                Console.WriteLine("Move, Attack, Drink");
                Console.Write("Write your command>");
                sData = Console.ReadLine();
                _sWriter.WriteLine(sData);
                Console.WriteLine("Response from server: ");
                _sWriter.Flush();


               
               

            
              //handles server responses
                char[] data;
                data = new char[1024];
                byte[] responseData;
                Int32 bytes = _sReader.Read(data,0,data.Length);
                responseData= Encoding.ASCII.GetBytes(data, 0, bytes);
                string result = System.Text.Encoding.UTF8.GetString(responseData);
                Console.WriteLine(result);
                // end of server responses
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();

            
            }

        }
    }
}
