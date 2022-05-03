
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PRace
{
    /// <summary>
    /// This class represent a position on the globe using latitude and longitude
    /// </summary>
    public class Position {

        /// <summary>
        /// create an instance of Position
        /// </summary>
        /// <param name="longitude">the longitude in radiant</param>
        /// <param name="latitude">the latitude in radiant</param>
        public Position(double longitude, double latitude) {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        private double latitude = 0;

        private double longitude = 0;

        /// <summary>
        /// struct representing a latitude or a longitude in degre, minute, second
        /// </summary>
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
        /// Update the 'longitude' and 'latitude' attributs
        /// </summary>
        /// <param name="longitude">the longitude in radiant</param>
        /// <param name="latitude">the latitude in radiant</param>
        public void Update(double longitude, double latitude) {
            this.longitude=longitude;
            this.latitude=latitude;
        }

        /// <summary>
        /// Create a <see cref="Coords"/> corresponding to the latitude attribut
        /// </summary>
        /// <returns>return a <see cref="Coords"/> corresponding to the latitude attribut</returns>
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

        /// <summary>
        /// Create a <see cref="Coords"/> corresponding to the longitude attribut
        /// </summary>
        /// <returns>return a <see cref="Coords"/> corresponding to the longitude attribut</returns>
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

        /// <summary>
        /// return the value of the longitude in radiant
        /// </summary>
        /// <returns>return the value of the longitude in radiant</returns>
        public double GetLongitude()
        {
            return this.longitude;
        }

        /// <summary>
        /// return the value of the latitude in radiant
        /// </summary>
        /// <returns>return the value of the latitude in radiant</returns>
        public double GetLatitude()
        {
            return this.latitude;
        }

        /// <summary>
        /// return the value of the longitude in degre
        /// </summary>
        /// <returns>return the value of the longitude in degre</returns>
        public double GetLatitudeAngle()
        {
            return latitude * UnityEngine.Mathf.PI / 180;
        }

        /// <summary>
        /// return the value of the latitude in degre
        /// </summary>
        /// <returns>return the value of the latitude in degre</returns>
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