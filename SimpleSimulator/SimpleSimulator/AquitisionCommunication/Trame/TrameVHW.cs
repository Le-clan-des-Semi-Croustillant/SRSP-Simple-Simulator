using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SimpleSimulator.AquitisionCommunication.Trame
{

    /*VHW - Vitesse par rapport à l'eau et cap suivi

         $--VHW,x.x,T,x.x,M,x.x,N,x.x,K*hh
        8 informations séparées par des virgules :
        Cap suivi, Degrés Vrais
        T = True
        Cap suivi, Degrés Magnétiques
        M = Magnetique
        Vitesse du bateau par rapport à l'eau en nœuds
        N = Nœuds
        Vitesse du bateau par rapport à l'eau ( en Kilomètres)
        K = Kilomètres,*/
    public class TrameVHW
    {
        public string TrameType { get; set; } = "GPVHW";
      
        public float CapDegres { get; set; }
        public float CapMagne { get; set; } = float.NaN;
        public float VitBateauNoeud { get; set; }
        public float VitBateauKm { get; set; } = float.NaN;
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
            string trame = TrameType + "," + CapDegres.ToString(CultureInfo.InvariantCulture) + "," + "T" + "," + (float.IsNaN(CapMagne) ? "": CapMagne.ToString(CultureInfo.InvariantCulture) )+ "," + "M" + "," + 
                VitBateauNoeud.ToString(CultureInfo.InvariantCulture) + ","+ "N" + "," + (float.IsNaN(VitBateauKm) ? "": VitBateauKm.ToString(CultureInfo.InvariantCulture)) + "," + "K";
            Controle = Checksum(trame);
            return "$" + trame + "*" + Controle;
        }
}
}
