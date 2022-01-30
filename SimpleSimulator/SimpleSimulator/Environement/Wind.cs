
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Environement{
    public class Wind {

        public Wind() {
        }

        private float windSpeed;

        private float directionWind;

        /// <summary>
        /// @param windSpeed 
        /// @param direction
        /// </summary>
        public void Update(float windSpeed, float direction) {
            this.directionWind = direction;
            this.windSpeed = windSpeed;
        }

        public void SetWindSpeed(float windSpeed)
        {
            this.windSpeed = windSpeed;
        }

        public void SetWindDirection(float windDirection)
        {
            this.directionWind= windDirection;
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