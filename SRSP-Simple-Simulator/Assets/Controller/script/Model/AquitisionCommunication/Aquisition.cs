
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using PRace;
using SimpleSimulator.AquitisionCommunication.Trame;
using Environement;

namespace AquitisionCommunication{
    public class Aquisition {

        public Aquisition(PRace.Race race) {
            this.my_race = race;
            this.sender = new Sender();
            sender.ip = "127.0.0.1";
            sender.port = 10114;
        }




        private PRace.Race my_race;

        private Sender sender;

        /// <summary>
        /// @param Mode mode
        /// </summary>
        public void SetUp(PRace.Mode mode) {
            switch (mode)
            {
                case PRace.Mode.Entrainement:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// @param float env
        /// </summary>
        public void change_Env(float env) {
            // TODO implement here
        }

        /// @param float id 
        /// <summary>
        /// @param float latitude 
        /// @param float longitude
        /// </summary>
        public void change_competitors(float id, float longitude, float latitude) {
            // TODO implement here
        }

        /// <summary>
        /// @param int id 
        /// @param float latitude 
        /// @param float longitude
        /// </summary>
        public void sentPosition(Dictionary<Environement.Conditions,float> condition, float SOG ,float COG, float cap, Position.Coords latitude, Position.Coords longitude, DateTime date) {
            TrameNMEA trameNMEA = new TrameNMEA();
            TrameRMC rmc = trameNMEA.rmc;
            TrameVHW vhw = trameNMEA.vhw;
            TrameMWV mwv = trameNMEA.mwv;
            TrameXDR xdr = trameNMEA.xdr;
            foreach (Conditions cond in condition.Keys)
            {
                switch (cond)
                {
                    case Conditions.WaveAmplitude:
                        break;
                    case Conditions.WaveLength:
                        break;
                    case Conditions.WaveDirection:
                        break;
                    case Conditions.CurrentSpeed:
                        break;
                    case Conditions.CurrentDirection:
                        break;
                    case Conditions.WindSpeed:
                        mwv.VitesseVent = condition[cond];
                        break;
                    case Conditions.WindDirection:
                        mwv.AngleVent = condition[cond];
                        break;
                    default:
                        break;
                }
            }
            //4916.45,N = Latitude 49 deg. 16.45 min North
            vhw.CapDegres = cap;
            vhw.VitBateauKm = SOG * 3.6f;
            vhw.VitBateauNoeud = SOG * 1.94384f;
            rmc.IndicateurLongitude = longitude.pos;
            rmc.Longitude = longitude.degre * 100 + (float)longitude.min + (float)longitude.sec/60;
            rmc.IndicateurLatitude = latitude.pos;
            float test = latitude.degre * 100 + (float)latitude.min + (float)latitude.sec / 60;
            rmc.Latitude = test;
            rmc.Heure = date;
            rmc.Date = date;
            sender.Send(trameNMEA);

        }

    }
}