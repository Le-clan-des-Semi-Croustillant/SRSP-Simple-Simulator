using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SimpleSimulator.AquitisionCommunication.Trame
{
    /*
             * Field Number:
        1) Transducer Type
        2) Measurement Data
        3) Units of measurement
        4) Name of transducer
        x) More of the same
        n) Checksum
        Example:
        $IIXDR,C,19.52,C,TempAir*19
        $IIXDR,P,1.02481,B,Barometer*29
            */
    public class TrameXDR
    {
        public string TrameType { get; set; } = "IIXDR";
        public List<XDRSub> XDRSubs { get; set; }
        public string Controle { get; set; }
        
        public string Checksum(string trame)
        {
            ushort checksum = 0;
            foreach (char c in trame)
            {
                checksum ^= Convert.ToByte(c);
            }
            return checksum.ToString("X2");
        }

        public override string? ToString()
        {
            string subTrame = "";
            foreach (XDRSub sub in XDRSubs)
            {
                subTrame += "," + sub.ToString();
            }
            string trame = TrameType + subTrame;
            Controle = Checksum(trame);
            return "$" + trame + "*" + Controle;
        }

}
}
