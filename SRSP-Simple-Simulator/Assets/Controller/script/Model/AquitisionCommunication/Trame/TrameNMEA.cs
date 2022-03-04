using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSimulator.AquitisionCommunication.Trame
{
    public class TrameNMEA
    {
        
        public TrameRMC rmc = new TrameRMC();
        public TrameMWV mwv = new TrameMWV();
        public TrameVHW vhw = new TrameVHW();
        public TrameXDR xdr = new TrameXDR()
        {
            XDRSubs = new List<XDRSub>()
        {
        new XDRSub{}
        }
        };
        public TrameRSA rsa = new TrameRSA();  
        //TrameAIVDM à ajouter
        //TrameVDM vdm = new TrameVDM();

        public override string? ToString()
        {
            return "\n" + rmc.ToString() + "\n" + mwv.ToString() + "\n" +
                vhw.ToString() + "\n" + xdr.ToString() + "\n" + rsa.ToString() + "\n"
                + "!AIVDM,1,1,,A,15o588? P0nOpAiBJ`Eoihgvt0000,0 * 78"; //+ vdm.ToString() + "\n";
        }

    }
}
