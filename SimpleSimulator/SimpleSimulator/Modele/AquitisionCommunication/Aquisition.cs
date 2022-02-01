
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace AquitisionCommunication{
    public class Aquisition {

        public Aquisition(Model.Race.Race race) {
            this.my_race = race;
        }




        private Model.Race.Race my_race;

        /// <summary>
        /// @param Mode mode
        /// </summary>
        public void SetUp(Model.Race.Mode mode) {
            switch (mode)
            {
                case Model.Race.Mode.Entrainement:
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
        public void sentPosition(int id, float latitude, float longitude) {
            // TODO implement here
        }

    }
}