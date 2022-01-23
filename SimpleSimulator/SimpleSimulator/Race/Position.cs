
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Race{
    public class Position {

        public Position(float longitude, float latitude) {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        private float latitude;

        private float longitude;




        /// <summary>
        /// @param float latitude 
        /// @param float longitude
        /// </summary>
        public void Update(float longitude, float latitude) {
            this.longitude=longitude;
            this.latitude=latitude;
        }

        public float GetLongitude()
        {
            return this.longitude;
        }

        public float GetLatitude()
        {
            return this.latitude;
        }

    }
}