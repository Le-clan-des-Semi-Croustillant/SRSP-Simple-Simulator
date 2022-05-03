
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Environement{

    /// <summary>
    /// This class manages the environmental values linked to the current
    /// </summary>
    public class Current
    {
        /// <summary>
        /// Create a Current instance
        /// </summary>
        public Current()
        {
        }

        private float currentSpeed = 0;
        private float currentDirection = 0;

        /// <summary>
        /// Set class attribut currentSpeed and currentDirection according to the inputs speed and direction
        /// </summary>
        /// <param name="speed">input speed</param>
        /// <param name="direction">input direction</param>
        public void Update(float speed, float direction)
        {
            this.currentSpeed = speed;
            this.currentDirection = direction;
        }

        /// <summary>
        /// Set class attribut currentSpeed according to the input currentSpeed
        /// </summary>
        /// <param name="currentSpeed">input speed</param>
        public void SetCurrentSpeed(float currentSpeed)
        {
            this.currentSpeed = currentSpeed;
        }

        /// <summary>
        /// Set class attribut currentDirection according to the input cd
        /// </summary>
        /// <param name="cd">input speed</param>
        public void SetCurrentDirection(float cd)
        {
            this.currentDirection = cd;
        }

        /// <summary>
        /// return currentSpeed attribut
        /// </summary>
        /// <returns>currentSpeed attribut</returns>
        public float GetCurrentSpeed()
        {
            return this.currentSpeed;
        }

        /// <summary>
        /// return currentDirection attribut
        /// </summary>
        /// <returns>currentDirection attribut</returns>
        public float GetCurrentDirection()
        {
            return this.currentDirection;
        }
    }
}