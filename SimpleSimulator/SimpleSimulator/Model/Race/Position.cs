
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRace
{
    public class Position {

        public Position(float longitude, float latitude) {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        private float latitude = 0;

        private float longitude = 0;




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

        public float GetLatitudeAngle()
        {
            return latitude * MathF.PI / 180;
        }

        public float GetLongitudeAngle()
        {
            return longitude * 2 * MathF.PI / 360;
        }

        public override string ToString()
        {
            string s = "Position:[ long:" + Convert.ToString(longitude) + "; lat:" + Convert.ToString(latitude) + "]";
            return s;
        }
    }
}