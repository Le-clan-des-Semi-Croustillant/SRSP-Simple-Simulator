
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using PRace;
using SimpleSimulator.AquitisionCommunication.Trame;

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
        public void sentPosition(int id, Position.Coords latitude, Position.Coords longitude, DateTime date) {
            TrameNMEA trameNMEA = new TrameNMEA();
            TrameRMC rmc = trameNMEA.rmc;
            rmc.IndicateurLongitude = longitude.pos;
            rmc.Longitude = longitude.degre + (float)longitude.min/60 + (float)longitude.sec/3600;
            rmc.IndicateurLatitude = latitude.pos;
            float test = latitude.degre + (float)latitude.min / 60 + (float)latitude.sec / 3600;
            rmc.Latitude = test;
            rmc.Heure = date;
            rmc.Date = date;
            sender.Send(trameNMEA);

        }

    }
}