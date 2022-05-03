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
    /// <summary>
    /// Trame MWV
    /// Important parameters : AngleVent wich refer to Wind angle and VitesseVent wich refer to Wind speed  
    /// the string Controle get the checksum value of the trame MWV
    /// </summary>
    public class TrameMWV
    {
        public string TrameType { get; set; } = "GPMWV";
        public float AngleVent { get; set; } = 0.0f;
        public char Reference { get; set; } = 'R';
        public float VitesseVent { get; set; } = 0.0f;
        public char Unite { get; set; } = 'N';
        public string Etat { get; set; } = "A";
        public string Controle { get; set; }
       
        /// <summary>
        /// Compute the checksum of a string, we use the current trame in our case
        /// It's computed with xor operation in between each caracters of the string trame
        /// </summary>
        /// <param name="trame">string trame to get checksum with</param>
        /// <returns></returns>
        public string Checksum(string trame)
        {
            ushort checksum = 0;
            foreach (char c in trame)
            {
                checksum ^= Convert.ToByte(c);
            }
            return checksum.ToString("X2");
        }

        /// <summary>
        /// Methode to compute the resulting MWV trame
        /// </summary>
        /// <returns></returns>
        public override string? ToString()
        {
            string trame = TrameType + "," + AngleVent.ToString(CultureInfo.InvariantCulture) + "," + Reference + "," + VitesseVent.ToString(CultureInfo.InvariantCulture) + "," + Unite + "," + Etat;
            Controle = Checksum(trame);
            return "$" + trame + "*" + Controle;
        }
}
}
