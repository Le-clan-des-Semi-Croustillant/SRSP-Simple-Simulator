using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSimulator.AquitisionCommunication.Trame
{
    /// <summary>
    /// Send full NMEA trame to a defined ip/port with Udp protocol
    /// </summary>
    public class Sender
    {
        public UdpClient udpClient = new UdpClient();
        public string ip { get; set; }
        public int port { get; set; }
        /// <summary>
        /// Send trame NMEA with Udp protocol
        /// </summary>
        /// <param name="trame">trameNMEA to be send</param>
        public void Send(TrameNMEA trame)
        {
            //set up the message to be send
            Byte[] sendTrame = Encoding.ASCII.GetBytes(trame.ToString());
            Console.WriteLine("trames" + trame);
            try
            {
                //send the message trame NMEA to ip/port 
                udpClient.Send(sendTrame, sendTrame.Length, this.ip, this.port);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
