
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Race{
    public class MyBoat {

        public MyBoat(int id, List<Polaire> polaires, Position pos)
        {
            this.id = id;
            this.allPolaire = polaires;
            this.currentPolaire = null;
            this.pos = pos;
            this.simPhy = new physicSimulator.physics_simulator();
            this.regulateurAmure = new RegulateurAmure();


        }

        private int id;

        private float cap;

        private ModeCommande mode;

        private RegulateurAmure regulateurAmure;

        private Polaire currentPolaire;

        private List<Polaire> allPolaire;

        private Position pos;

        private physicSimulator.physics_simulator simPhy;



        public int GetId()
        {
            return id;
        }

        /// <summary>
        /// @param int cap
        /// </summary>
        public void setCap(int cap) {
            this.cap = cap;
        }

        public float getCap()
        {
            return this.cap;
        }

        public float GetCapRegulateurAmure()
        {
            return this.regulateurAmure.Get_cap();
        }


        public void DisplayPolaire(Polaire pol) {
            this.currentPolaire = pol;
        }

        /// <summary>
        /// @param ModeCommande mode
        /// </summary>
        public void switchMode(ModeCommande mode) {
            this.mode = mode;
        }

        /// <summary>
        /// @param ModeCommande modeCommande 
        /// @param DegreeIncrement D
        /// </summary>
        public void IncrementerCap(ModeCommande modeCommande, DegreeIncrement DI) {
            if (modeCommande == ModeCommande.RegulateurAmure)
            {
                this.regulateurAmure.SetCap(regulateurAmure.Get_cap() + (float)DI);
            }
            else
            {
                cap = cap + (float)DI;
            }
        }

        public void setPosition(Position pos)
        {
            this.pos = pos;
        }

        /// <summary>
        /// @param int factor
        /// </summary>
        public void setAcceleration(int factor) {
            // TODO implement here
        }

        public void nextPosition() {
            this.simPhy.ComputePhysique();
        }

        public Polaire getcurrentPolaire() {
            return this.currentPolaire;
        }

        public List<Polaire> getAvailablePolaire()
        {
            return this.allPolaire;
        }

        public void SetPolaire(string name) {
            bool change = false; 
            for (int i = 0; i < this.allPolaire.Count(); i++)
            {
                if (this.allPolaire[i].getName() == name)
                {
                    change = true;
                    this.currentPolaire = this.allPolaire[i];
                }
            }
        }

    }
}