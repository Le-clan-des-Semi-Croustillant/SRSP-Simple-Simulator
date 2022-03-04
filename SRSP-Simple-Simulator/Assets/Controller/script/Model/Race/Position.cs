
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PRace
{
    public class Position {

        public Position(double longitude, double latitude) {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        private double latitude = 0;

        private double longitude = 0;

        public struct Coords
        {
            public Coords(char pos, int degre, int min, int sec)
            {
                this.pos = pos;
                this.degre = degre;
                this.min = min;
                this.sec = sec;
            }

            public char pos { get; }
            public int degre { get; }
            public int min { get; }
            public int sec { get; }

            public override string ToString() => $"({pos}, {degre}, {min}, {sec})";
        }


        /// <summary>
        /// @param float latitude 
        /// @param float longitude
        /// </summary>
        public void Update(double longitude, double latitude) {
            this.longitude=longitude;
            this.latitude=latitude;
        }

        public Coords GetCoordLat()
        {
            Coords coordLat;
            char pos;
            float lat;
            int degre, min, sec;
            if (latitude < 90)
            {
                pos = 'S';
                lat = (float) (90.0 - latitude);
            }
            else
            {
                pos = 'N';
                lat = (float)(latitude-90);
            }
            degre = (int)lat;
            lat = (lat - degre) * 60;
            min = (int)lat;
            lat = (lat - min) * 60;
            sec = (int)lat;
            coordLat = new Coords( pos, degre, min, sec);
            return coordLat;
        }

        public Coords GetCoordLong()
        {
            Coords coordLong;
            char pos;
            float lon;
            int degre, min, sec;
            if (longitude < 180)
            {
                pos = 'E';
                lon = (float)longitude;
            }
            else
            {
                pos = 'W';
                lon = (float)(longitude - 180);
                lon = 180 - lon;
            }
            degre = (int)lon;
            lon = (lon - degre) * 60;
            min = (int)lon;
            lon = (lon - min) * 60;
            sec = (int)lon;
            coordLong = new Coords(pos, degre, min, sec);
            return coordLong;
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
            return latitude * UnityEngine.Mathf.PI / 180;
        }

        public double GetLongitudeAngle()
        {
            return longitude * 2 * Mathf.PI / 360;
        }

        public override string ToString()
        {
            string s = "Position:[ long:" + GetCoordLong().ToString() + "; lat:" + GetCoordLat().ToString() + "]";
            return s;
        }

        public override bool Equals(System.Object o)
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