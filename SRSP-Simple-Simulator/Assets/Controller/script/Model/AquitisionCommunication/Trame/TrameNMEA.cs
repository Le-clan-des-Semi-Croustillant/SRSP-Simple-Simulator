using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSimulator.AquitisionCommunication.Trame
{
    /// <summary>
    /// Compute the resulting full NMEA trame with a TrameRMC/ TrameMWV / trame VHW
    /// </summary>
    public class TrameNMEA
    {
        
        public TrameRMC rmc = new TrameRMC();
        public TrameMWV mwv = new TrameMWV();
        public TrameVHW vhw = new TrameVHW();
        /*public TrameXDR xdr = new TrameXDR()
        {
            XDRSubs = new List<XDRSub>()
        {
        new XDRSub{}
        }
        };
        public TrameRSA rsa = new TrameRSA();  pas necessaire*/

        //TrameAIVDM à ajouter pour Asynchrone
        //TrameVDM vdm = new TrameVDM(); //pas necessaire

        /// <summary>
        /// Compute the resulting full trame NMEA string
        /// </summary>
        /// <returns></returns>
        public override string? ToString()
        {
            return "\n" + rmc.ToString() + "\n" + mwv.ToString() + "\n" +
                vhw.ToString() + "\n"; //+ vdm.ToString() + "\n";
        }

    }
}
