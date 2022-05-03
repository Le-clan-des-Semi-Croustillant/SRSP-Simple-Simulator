
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Environement{

    /// <summary>
    /// This class manages the environmental values linked to the wind
    /// </summary>
    public class Wind {
        
        /// 
        /// <summary>
        /// Create a Wind instance
        /// </summary>
        public Wind() {
        }

        private float windSpeed = 0;

        private float directionWind = 0;

        /// <summary>
        /// Set class attribut windSpeed and directionWind according to the inputs windSpeed and direction
        /// </summary>
        /// <param name="speed">input windSpeed</param>
        /// <param name="direction">input direction</param>
        public void Update(float windSpeed, float direction) {
            this.directionWind = direction;
            this.windSpeed = windSpeed;
        }

        /// <summary>
        /// Set class attribut windSpeed according to the input windSpeed
        /// </summary>
        /// <param name="currentSpeed">input windSpeed</param>
        public void SetWindSpeed(float windSpeed)
        {
            this.windSpeed = windSpeed;
        }

        /// <summary>
        /// Set class attribut windDirection according to the input windDirection
        /// </summary>
        /// <param name="cd">input windDirection</param>
        public void SetWindDirection(float windDirection)
        {
            this.directionWind= windDirection;
        }

        /// <summary>
        /// return windSpeed attribut
        /// </summary>
        /// <returns>windSpeed attribut</returns>
        public float GetWindSpeed()
        {
            return this.windSpeed;
        }

        /// <summary>
        /// return directionWind attribut
        /// </summary>
        /// <returns>directionWind attribut</returns>
        public float GetWindDirection()
        {
            return this.directionWind;
        }

    }
}