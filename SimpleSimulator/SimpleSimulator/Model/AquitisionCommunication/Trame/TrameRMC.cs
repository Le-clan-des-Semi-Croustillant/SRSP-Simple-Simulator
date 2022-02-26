using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SimpleSimulator.AquitisionCommunication.Trame
{
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
        public string NormalizeHeure(DateTime date)
        {
            return date.Hour.ToString() + date.Minute.ToString() + date.Second.ToString();// + "." + date.Millisecond.ToString();
        }

        public string NormalizeDate(DateTime date)
        {
            string year = date.Year.ToString();
            return date.Day.ToString() + date.Month.ToString() + year[2] + year[3];
        }

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
            string trame = TrameType + "," + NormalizeHeure(Heure) + "," + Etat + "," + Latitude.ToString(CultureInfo.InvariantCulture) 
                + "," + IndicateurLatitude + "," + Longitude.ToString(CultureInfo.InvariantCulture) + "," + IndicateurLongitude + "," + 
                Vitesse.ToString(CultureInfo.InvariantCulture) + "," + Road.ToString(CultureInfo.InvariantCulture)
                + "," + NormalizeDate(Date) + "," + Magneto.ToString(CultureInfo.InvariantCulture) + "," + Sens + "," + Mode;
            Controle = Checksum(trame);
            return "$" + trame + "*" + Controle;
        }


 
    }
}
