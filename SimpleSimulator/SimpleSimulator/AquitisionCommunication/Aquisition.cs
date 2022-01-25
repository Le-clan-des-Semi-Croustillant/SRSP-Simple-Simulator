
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquitisionCommunication{
    public class Aquisition {

        public Aquisition() {
            this.my_race = new Race.Race();
        }




        public Race.Race my_race;

        /// <summary>
        /// @param Mode mode
        /// </summary>
        public void SetUp( Race.Mode mode) {
            // TODO implement here
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
        public void change_competitors(float id, float latitude, float longitude) {
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