
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Race{
    public class WayPoint {

        public WayPoint(int id, string nom, Position position) {
            this.nom = nom;
            this.id = id;
            this.position = position;
        }

        public WayPoint(int id, string nom, float longitude, float latitude)
        {
            this.nom = nom;
            this.id=id;
            this.position = new Position(longitude, latitude);
        }

        private int id;

        private string nom;
        
        private Position position;

        public int GetId()
        {
            return id;
        }

        public string Getnom()
        {
            return nom;
        }

        public Position GetPosition()
        {
            return this.position;
        }

        public void SetPosition(Position pos)
        {
            this.position=pos;
        }

        public void SetPosition(float latitude, float longitude)
        {
            this.position = new Position(latitude, longitude);
        }

    }
} 