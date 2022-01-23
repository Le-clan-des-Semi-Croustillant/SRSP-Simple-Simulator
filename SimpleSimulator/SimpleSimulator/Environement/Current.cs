
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