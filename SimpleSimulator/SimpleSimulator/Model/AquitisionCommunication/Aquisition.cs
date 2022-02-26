
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace AquitisionCommunication{
    public class Aquisition {

        public Aquisition(PRace.Race race) {
            this.my_race = race;
        }




        private PRace.Race my_race;

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

        /// <summary>
        /// @param float id 
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
        public void sentPosition(int id, double latitude, double longitude) {
            
        }

    }
}