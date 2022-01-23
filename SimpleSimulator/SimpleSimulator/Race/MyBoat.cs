
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Race{
    public class MyBoat {

        public MyBoat() {
            this.currentPolaire = new Polaire(0,0,0);
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
            return new Polaire(0,0,0);
            // TODO implement here
        }

        public void SetPolaire() {
            // TODO implement here
        }

    }
}