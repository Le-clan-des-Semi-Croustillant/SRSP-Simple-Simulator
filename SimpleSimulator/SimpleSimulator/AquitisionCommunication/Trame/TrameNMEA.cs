using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSimulator.AquitisionCommunication.Trame
{
    public class TrameNMEA
    {
        
        TrameRMC rmc = new TrameRMC();
        TrameMWV mwv = new TrameMWV();
        TrameVHW vhw = new TrameVHW();
        TrameXDR xdr = new TrameXDR();
        TrameRSA rsa = new TrameRSA();  
        //TrameAIVDM à ajouter
        //TrameVDM vdm = new TrameVDM();

        public override string? ToString()
        {
            return rmc.ToString() + "\n" + mwv.ToString() + "\n" +
                vhw.ToString() + "\n" + xdr.ToString() + "\n" + rsa.ToString() + "\n"; //+ vdm.ToString() + "\n";
        }

        

    }
}
