
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Race{
    public class Position {

        public Position() {
            this.competitor = null;
        }

        public float latitude;

        public float longitude;

        public Competitor competitor;



        /// <summary>
        /// @param float latitude 
        /// @param float longitude
        /// </summary>
        public void Update(float latitude, float longitude) {
            // TODO implement here
        }

    }
}