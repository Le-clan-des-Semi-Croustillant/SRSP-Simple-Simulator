
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Environement{
    public class Wind {

        public Wind() {
        }

        public float windSpeed;

        public float directionWind;

        /// <summary>
        /// @param windSpeed 
        /// @param direction
        /// </summary>
        public void Update(float windSpeed, float direction) {
            this.directionWind = direction;
            this.windSpeed = windSpeed;
        }

        public float GetWindSpeed()
        {
            return this.windSpeed;
        }

        public float GetWindDirection()
        {
            return this.directionWind;
        }

    }
}