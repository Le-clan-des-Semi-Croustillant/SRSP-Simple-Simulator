
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Environement{
    public class Environment {

        public Environment() {
            this.wave = new Wave();
            this.current = new Current();
            this.wind = new Wind();
        }

        private Wave wave;
        private Current current;
        private Wind wind;



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
            this.current.Update(speed, direction);
        }

        public void setEnvironment(Dictionary<Conditions, float> environment)
        {
            foreach (Conditions condition in environment.Keys)
            {
                switch (condition)
                {
                    case Conditions.WaveAmplitude:
                        this.wave.SetWaveAmplitude(environment[condition]);
                        break;
                    case Conditions.WaveLength:
                        this.wave.SetWaveLength(environment[condition]);
                        break;
                    case Conditions.WaveDirection:
                        this.wave.SetWaveDirection(environment[condition]);
                        break;
                    case Conditions.CurrentSpeed:
                        this.current.SetCurrentSpeed(environment[condition]);
                        break;
                    case Conditions.CurrentDirection:
                        this.wave.SetWaveDirection(environment[condition]);
                        break;
                    case Conditions.WindSpeed:
                        this.wind.SetWindSpeed(environment[condition]);
                        break;
                    case Conditions.WindDirection:
                        this.wind.SetWindDirection(environment[condition]);
                        break;
                    default:
                        break;
                }
            }
        }

        public Dictionary<Conditions, float> getEnvState() {
            Dictionary<Conditions, float> envState = new Dictionary<Conditions,float>();
            envState.Add(Conditions.WindDirection, this.wind.GetWindDirection());
            envState.Add(Conditions.WindSpeed, this.wind.GetWindSpeed());
            envState.Add(Conditions.CurrentDirection, this.current.GetCurrentDirection());
            envState.Add(Conditions.CurrentSpeed, this.current.GetCurrentSpeed());
            envState.Add(Conditions.WaveDirection, this.wave.GetDirection());
            envState.Add(Conditions.WaveAmplitude,this.wave.GetAmplitude());
            envState.Add(Conditions.WaveLength, this.wave.GetWaveLength());
            return envState;
        }

    }
}