
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Race{
    public class MyBoat {

        public MyBoat()
        {
            var dic = new Dictionary<float, Dictionary<float, float>>();
            this.currentPolaire = new Polaire(dic);
        }

        public int id;

        public float HDG;

        public float HDGVent;

        public float cap;

        public Polaire currentPolaire;



        /// <summary>
        /// @param int cap
        /// </summary>
        public void setCap(int cap) {
            // TODO implement here
        }

        /// <summary>
        /// @param int cap
        /// </summary>
        public void setRegulateur(int cap) {
            // TODO implement here
        }

        public void DisplayPolaire() {
            // TODO implement here
        }

        /// <summary>
        /// @param ModeCommande mode
        /// </summary>
        public void switchMode(ModeCommande mode) {
            // TODO implement here
        }

        /// <summary>
        /// @param ModeCommande modeCommande 
        /// @param DegreeIncrement D
        /// </summary>
        public void IncrementerCap(ModeCommande modeCommande, DegreeIncrement D) {
            // TODO implement here
        }

        /// <summary>
        /// @param Wind wind
        /// </summary>
        public void setHDGWind(Environement.Wind wind) {
            // TODO implement here
        }

        /// <summary>
        /// @param int factor
        /// </summary>
        public void setAcceleration(int factor) {
            // TODO implement here
        }

        public void nextPosition() {
            // TODO implement here
        }

        public Polaire getPolaire() {
            var dic = new Dictionary<float,Dictionary<float,float>>();
            return new Polaire(dic);
            // TODO implement here
        }

        public void SetPolaire() {
            // TODO implement here
        }

    }
}