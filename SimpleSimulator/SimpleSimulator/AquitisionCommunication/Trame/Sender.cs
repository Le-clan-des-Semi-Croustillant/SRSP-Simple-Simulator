using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSimulator.AquitisionCommunication.Trame
{
    public class Sender
    {
        public UdpClient udpClient = new UdpClient();
        public void Send(TrameNMEA trame, string ip, int port)
        {
            Byte[] sendTrame = Encoding.ASCII.GetBytes(trame.ToString());
            Console.WriteLine("trames" + trame);
            try
            {
                udpClient.Send(sendTrame, sendTrame.Length, ip, port);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
