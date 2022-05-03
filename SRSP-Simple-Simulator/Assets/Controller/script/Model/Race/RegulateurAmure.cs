
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRace
{
    /// <summary>
    /// This class maintains the cap in regard of wind during wind mode(<see cref="ModeCommande.RegulateurAmure"/>
    /// </summary>
    public class RegulateurAmure{

        /// <summary>
        /// create an instance of RegulateurAmure
        /// </summary>
        /// <param name="boat">The <see cref="Boat"/> whose course must be maintained</param>
        public RegulateurAmure(Boat boat) {
            this.cap = 0;
            this.boat = boat;
        }

        private float cap; // cap in regard of the wind
        private Boat boat;

        /// <summary>
        /// Update the heading of the boat in regard of the wind
        /// </summary>
        /// <param name="env">Enviromnentale conditions</param>
        public void Update_cap(Environement.Environment env) {
            float windDir = 0;
            env.getEnvState().TryGetValue(Environement.Conditions.WindDirection, out windDir);
            this.boat.setCap( windDir + cap );
        }

        public float Get_cap()
        { 
            return this.cap;
        }


        public void SetCap(float cap)
        {
            this.cap = (cap + 360) % 360;
        }
            
    }
}