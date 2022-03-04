
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Environement{
    public class Current
    {

        public Current()
        {
        }

        private float currentSpeed;
        private float currentDirection;

        public void Update(float speed, float direction)
        {
            this.currentSpeed = speed;
            this.currentDirection = direction;
        }

        public void SetCurrentSpeed(float currentSpeed)
        {
            this.currentSpeed = currentSpeed;
        }

        public void SetCurrentDirection(float cd)
        {
            this.currentDirection = cd;
        }
        public float GetCurrentSpeed()
        {
            return this.currentSpeed;
        }

        public float GetCurrentDirection()
        {
            return this.currentDirection;
        }
    }
}