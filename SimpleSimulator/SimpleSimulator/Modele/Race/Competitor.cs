
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Race{
    public class Competitor {

        public Competitor(int id) {
            this.id = id;
            this.position = new Position(0, 0);
        }

        public Competitor(int id, Position position)
        {
            this.id = id;
            this.position = position;
        }

        private int id;

        private Position position;

        public void SetPosition(Position pos) {
            this.position = pos;
        }

        public Position GetPosition()
        {
            return this.position;
        }

        public int GetId()
        {
            return this.id;
        }
    }
}