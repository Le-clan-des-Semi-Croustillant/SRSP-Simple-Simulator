using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SimpleSimulator.AquitisionCommunication.Trame
{
    /*
     *  $--RSA,x.x,A,x.x,A*hh
        4 informations séparées par des virgules :
        Mesure de l'angle de barre tribord (ou simple), "-" signifie vers bâbord s'il n'y a qu'un seul appareil de mesure.
        Etat, A signifie donnée valide
        Mesure de l'angle de barre bâbord
        Etat, A signifie donnée valide*/
    public class TrameRSA
    {
        public string TrameType { get; set; } = "IIRSA";

        public float BarreT { get; set; } = -2f;
        public string EtatT { get; set; } = "A";
        public float BarreB { get; set; } = 0f;
        public string EtatB { get; set; } = "V";
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
            string trame = TrameType + "," + BarreT.ToString(CultureInfo.InvariantCulture) + "," + EtatT + "," + BarreB.ToString(CultureInfo.InvariantCulture) + "," + EtatB;
            Controle = Checksum(trame);
            return "$" + trame + "*" + Controle;
        }
}
}
