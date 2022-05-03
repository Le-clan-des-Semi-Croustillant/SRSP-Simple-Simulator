
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Environement{

    /// <summary>
    /// This class manages the environmental values linked to the waves
    /// </summary>
    public class Wave {

        /// <summary>
        /// Create a Wave instance
        /// </summary>
        public Wave() {
            this.direction = 0;
            this.amplitude = 0;
            this.waveLength = 0;
        }

        private float direction;

        private float amplitude;

        private float waveLength;


        /// <summary>
        /// Set class attribut direction, amplitude and waveLength according to the inputs parameters
        /// </summary>
        /// <param name="direction">input direction</param>
        /// <param name="amplitude">input amplitude</param>
        /// <param name="waveLength">input waveLength</param>
        public void Update(float direction, float amplitude, float waveLength) {
            this.direction = direction;
            this.amplitude = amplitude;
            this.waveLength = waveLength;
        }

        /// <summary>
        /// Set class attribut direction according to the input parameter
        /// </summary>
        /// <param name="wd">input direction</param>
        public void SetWaveDirection(float wd)
        {
            this.direction=wd;
        }

        /// <summary>
        /// Set class attribut amplitude according to the input parameter
        /// </summary>
        /// <param name="amplitude">input amplitude</param>
        public void SetWaveAmplitude(float amplitude)
        {
            this.amplitude = amplitude;
        }

        /// <summary>
        /// Set class attribut waveLength according to the input parameter
        /// </summary>
        /// <param name="length">input waveLength</param>
        public void SetWaveLength(float length)
        {
            this.waveLength=length;
        }

        /// <summary>
        /// return direction attribut
        /// </summary>
        /// <returns>direction attribut value</returns>
        public float GetDirection() {
            return this.direction;
        }

        /// <summary>
        /// return amplitude attribut
        /// </summary>
        /// <returns>amplitude attribut value</returns>
        public float GetAmplitude()
        {
            return this.amplitude;
        }

        /// <summary>
        /// return waveLength attribut
        /// </summary>
        /// <returns>waveLength attribut value</returns>
        public float GetWaveLength()
        {
            return this.waveLength;
        }

    }
}