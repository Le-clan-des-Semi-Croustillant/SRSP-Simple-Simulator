using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * $GPRMC,225446,A,4916.45,N,12311.12,W,000.5,054.7,191194,020.3,E*68

 * 
 225446 = Heure du Fix 22:54:46 UTC
A = Alerte du logiciel de navigation ( A = OK, V = warning (alerte)
4916.45,N = Latitude 49 deg. 16.45 min North
12311.12,W = Longitude 123 deg. 11.12 min West
000.5 = vitesse sol, Noeuds
054.7 = cap (vrai)
191194 = Date du fix 19 Novembre 1994
020.3,E = Déclinaison Magnétique 20.3 deg Est
*68 = checksum obligatoire

 */

namespace SimpleSimulator.AquitisionCommunication.Trame
{
    /// <summary>
    /// Trame RMC
    /// Important parameters :
    /// Heure wich refer to the date time Hour
    /// Date with refer to the date time Day
    /// Latitude / indicateur Latitude 
    /// Longitude / indicateur Longitude
    /// Vitesse witch refer to speed in knots
    /// Controle wich get the checksum string 
    /// </summary>
    public class TrameRMC
    {
        public string TrameType { get; set; } = "GPRMC";
        public DateTime Heure { get; set; } = DateTime.Now;
        public string Etat { get; set; } = "A";
        public float Latitude { get; set; } = 0f;
        public char IndicateurLatitude { get; set; } = 'N';
        public float Longitude { get; set; } = 0f;
        public char IndicateurLongitude { get; set; } = 'W';
        public float Vitesse { get; set; } = 0f;
        public float Road { get; set; } = 0f;
        public DateTime Date { get; set; } = DateTime.Now;
        public float Magneto { get; set; } = 0.0f;
        public char Sens { get; set; } = 'W';
        public char Mode { get; set; } = 'A';
        public string Controle { get; set; }

        /// <summary>
        /// compute the accepted hour time to the second 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string NormalizeHeure(DateTime date)
        {
            return date.Hour.ToString() + date.Minute.ToString() + date.Second.ToString();// + "." + date.Millisecond.ToString();
        }

        /// <summary>
        /// compute the accepted date day
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string NormalizeDate(DateTime date)
        {
            string year = date.Year.ToString();
            if (year.Length == 4)
            {
                return date.Day.ToString() + date.Month.ToString() + year[2] + year[3];
            }
            if (year.Length == 3)
            {
                return date.Day.ToString() + date.Month.ToString() + year[1] + year[2];
            }
            if (year.Length == 2)
            {
                return date.Day.ToString() + date.Month.ToString() + year[0] + year[1];
            }
            if (year.Length == 1)
            {
                return date.Day.ToString() + date.Month.ToString() + year[0];
            }
            else
            {
                return date.Day.ToString() + date.Month.ToString() + year;
            }
        }

        /// <summary>
        /// compute the resulting checksum of a trame RMC
        /// </summary>
        /// <param name="trame">string of a trame RMC</param>
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
        /// compute the resulting trame RMC in string
        /// </summary>
        /// <returns></returns>
        public override string? ToString()
        {
            string trame = TrameType + "," + NormalizeHeure(Heure) + "," + Etat + "," + Latitude.ToString(CultureInfo.InvariantCulture) 
                + "," + IndicateurLatitude + "," + Longitude.ToString(CultureInfo.InvariantCulture) + "," + IndicateurLongitude + "," + 
                Vitesse.ToString(CultureInfo.InvariantCulture) + "," + Road.ToString(CultureInfo.InvariantCulture)
                + "," + NormalizeDate(Date) + "," + Magneto.ToString(CultureInfo.InvariantCulture) + "," + Sens + "," + Mode;
            Controle = Checksum(trame);
            return "$" + trame + "*" + Controle;
        }


 
    }
}
