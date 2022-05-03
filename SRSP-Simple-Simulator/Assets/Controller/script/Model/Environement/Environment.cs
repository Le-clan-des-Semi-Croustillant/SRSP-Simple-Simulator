
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Environement{
    /// <summary>
    /// The class contains and manages all the envorinmentales values
    /// </summary>
    public class Environment {

        /// <summary>
        /// Create an Environment instance 
        /// </summary>
        /// <remarks>
        /// It creates also instances of <see cref="Environement.Current"/>, <see cref="Environement.Wave"/> and <see cref="Environement.Wind"/> and assigned them to wave, current and wind attribut.
        /// </remarks>
        public Environment() {
            this.wave = new Wave();
            this.current = new Current();
            this.wind = new Wind();
        }

        private Wave wave;
        private Current current;
        private Wind wind;


        /// <summary>
        /// Update directionWind and windSpeed of wind attribut according to inputs
        /// </summary>
        /// <param name="windSpeed"></param>
        /// <param name="direction"></param>
        public void UpdateWind(float windSpeed, float direction) {
            this.wind.Update(windSpeed, direction);
        }

        /// <summary>
        /// Update waveLength, amplitude and direction of wave attribut according to inputs
        /// </summary>
        /// <param name="amplitude"></param>
        /// <param name="waveLength"></param>
        /// <param name="direction"></param>
        public void UpdateWave(float amplitude, float waveLength, float direction) {
            this.wave.Update(direction, amplitude, waveLength);
        }

        /// <summary>
        /// Update currentDirection and currentSpeed of current attribut according to inputs
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="direction"></param>
        public void UpdateCurrent(float speed, float direction) {
            this.current.Update(speed, direction);
        }

        /// <summary>
        /// for all <see cref="Conditions"/> keys in the input dictionary, modifie the correponding environmentale value according to the input
        /// </summary>
        /// <param name="environment">dictionary containing environmental values to set <see cref="Conditions"/></param>
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

        /// <summary>
        /// create and return a dictionary containing all environemental as values using <see cref="Conditions"/> as keys
        /// </summary>
        /// <returns>return a dictionary containing all environemental values</returns>
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