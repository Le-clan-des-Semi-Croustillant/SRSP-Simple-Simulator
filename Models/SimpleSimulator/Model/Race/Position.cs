
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRace
{
    public class Position {

        public Position(double longitude, double latitude) {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        private double latitude = 0;

        private double longitude = 0;




        /// <summary>
        /// @param float latitude 
        /// @param float longitude
        /// </summary>
        public void Update(double longitude, double latitude) {
            this.longitude=longitude;
            this.latitude=latitude;
        }

        public double GetLongitude()
        {
            return this.longitude;
        }

        public double GetLatitude()
        {
            return this.latitude;
        }

        public double GetLatitudeAngle()
        {
            return latitude * MathF.PI / 180;
        }

        public double GetLongitudeAngle()
        {
            return longitude * 2 * MathF.PI / 360;
        }

        public override string ToString()
        {
            string s = "Position:[ long:" + Convert.ToString(longitude) + "; lat:" + Convert.ToString(latitude) + "]";
            return s;
        }

        public override bool Equals(Object o)
        {
            if (o is null)
            {
                return false;
            }
            else if (this.GetType() != o.GetType())
            {
                return false;
            }
            else
            {
                Position pos = (Position)o;
                return pos.latitude == this.latitude && pos.longitude == this.longitude;
            }
        }
    }
}