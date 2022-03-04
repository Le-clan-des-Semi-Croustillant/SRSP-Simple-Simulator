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
        public string ip { get; set; }
        public int port { get; set; }
        public void Send(TrameNMEA trame)
        {
            Byte[] sendTrame = Encoding.ASCII.GetBytes(trame.ToString());
            Console.WriteLine("trames" + trame);
            try
            {
                udpClient.Send(sendTrame, sendTrame.Length, this.ip, this.port);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
