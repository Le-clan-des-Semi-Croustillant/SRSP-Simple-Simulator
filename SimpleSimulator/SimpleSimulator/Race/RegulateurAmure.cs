
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Race{
    public class RegulateurAmure{

        public RegulateurAmure() {
            this.cap = 0;
        }

        private float cap;


        /// <summary>
        /// @param MyBoat boat
        /// </summary>
        public void Update_cap(float cap) {
            this.cap = cap;
        }

        public float Get_cap()
        { 
            return this.cap;
        }


        public void SetCap(float cap)
        {
            this.cap = cap;
        }
            
    }
}