
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Environement{
    public class Environment {

        public Environment() {
            this.wave = new Wave();
            this.waterCurrent = new Current();
            this.wind = new Wind();
        }

        public Wave wave;
        public Current waterCurrent;
        public Wind wind;



        /// <summary>
        /// @param float windSpeed 
        /// @param float direction
        /// </summary>
        public void UpdateWind( float direction, float windSpeed) {
            this.wind.Update(windSpeed, direction);
        }

        /// <summary>
        /// @param float direction 
        /// @param float amplitude 
        /// @param float wave length
        /// </summary>
        public void UpdateWave(float direction, float amplitude, float waveLength) {
            this.wave.Update(direction, amplitude, waveLength);
        }

        /// <summary>
        /// @param float speed 
        /// @param float direction
        /// </summary>
        public void UpdateCurrent(float speed, float direction) {
            this.waterCurrent.Update(speed, direction);
        }

        public Dictionary<Conditions, float> getEnvState() {
            Dictionary<Conditions, float> envState = new Dictionary<Conditions,float>();
            envState.Add(Conditions.WindDirection, this.wind.GetWindDirection());
            envState.Add(Conditions.WindSpeed, this.wind.GetWindSpeed());
            envState.Add(Conditions.CurrentDirection, this.waterCurrent.GetCurrentDirection());
            envState.Add(Conditions.CurrentSpeed, this.waterCurrent.GetCurrentSpeed());
            envState.Add(Conditions.WaveDirection, this.wave.GetDirection());
            envState.Add(Conditions.WaveAmplitude,this.wave.GetAmplitude());
            envState.Add(Conditions.WaveLength, this.wave.GetWaveLength());
            return envState;
        }

    }
}