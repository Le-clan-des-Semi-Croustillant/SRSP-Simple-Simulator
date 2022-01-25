using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SimpleSimulator.AquitisionCommunication.Trame
{
    /*VDM - Système d'information automatique (AIS) rapports de position des cibles
        9 informations séparées par des virgules :
        Heure (UTC)
        Numéro MMSI
        latitude
        Longitude
        Vitesse en nœuds
        Cap
        Vitesse fond
        Vitesse de rotation
        Statut de navigation*/
    public class TrameVDM
    {
        public string TrameType { get; set; } = "AIVDM";
        public DateTime Heure { get; set; } = DateTime.Now;
        public string Etat { get; set; } = "A";
        public float Latitude { get; set; }
        public char IndicateurLatitude { get; set; }
        public float Longitude { get; set; }
        public char IndicateurLongitude { get; set; }
        public float Vitesse { get; set; }
        public float Road { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public float Magneto { get; set; }
        public char Sens { get; set; }
        public char Mode { get; set; }
        public string Controle { get; set; }
        public string NormalizeHeure(DateTime date)
        {
            return date.Hour.ToString() + date.Minute.ToString() + date.Second.ToString() + "." + date.Millisecond.ToString();
        }

        public string NormalizeDate(DateTime date)
        {
            return date.Day.ToString() + date.Month.ToString() + date.Year.ToString();
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
            string trame = TrameType + "," + NormalizeHeure(Heure) + "," + Etat + "," + Latitude + "," + IndicateurLatitude + "," + Longitude + "," + IndicateurLongitude + "," + Vitesse + "," + Road
                + "," + NormalizeDate(Date) + "," + Magneto + "," + Sens + "," + Mode;
            Controle = Checksum(trame);
            return "$" + trame + "*" + Controle;
        }

}
}
