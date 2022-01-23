
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Environement{
    public class Wave {

        public Wave() {
            this.direction = 0;
            this.amplitude = 0;
            this.waveLength = 0;
        }

        private float direction;

        private float amplitude;

        private float waveLength;


        /// <summary>
        /// @param direction 
        /// @param amplitude 
        /// @param wave length
        /// </summary>
        public void Update(float direction, float amplitude, float waveLength) {
            this.direction = direction;
            this.amplitude = amplitude;
            this.waveLength = waveLength;
        }

        public float GetDirection() {
            return this.direction;
        }

        public float GetAmplitude()
        {
            return this.amplitude;
        }

        public float GetWaveLength()
        {
            return this.waveLength;
        }

    }
}