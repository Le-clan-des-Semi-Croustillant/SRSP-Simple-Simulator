using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SimpleSimulator.AquitisionCommunication.Trame
{
    /*
     * $--MWV,x.x,a,x.x,a*hh
        5 informations séparées par des virgules :
        Angle du vent, de 0 à 360 degrés
        Référence, R = Relative, T = Vraie,
        Vitesse du vent,
        Unité de vitesse du vent, K/M/N,
        Etat, A = Données valide,*/
    public class TrameMWV
    {
        public string TrameType { get; set; } = "GPMWV";
        public float AngleVent { get; set; } = 0.0f;
        public char Reference { get; set; } = 'N';
        public float VitesseVent { get; set; } = 0.0f;
        public char Unite { get; set; } = 'R';
        public string Etat { get; set; } = "A";
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
            string trame = TrameType + "," + AngleVent.ToString(CultureInfo.InvariantCulture) + "," + Reference + "," + VitesseVent.ToString(CultureInfo.InvariantCulture) + "," + Unite + "," + Etat;
            return "$" + trame + "*" + Controle;
        }
}
}
