
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRace
{
    public class Boat {

        public Boat()
        {
            this.regulateurAmure = new RegulateurAmure();
            this.pos = new Position(0,0);
        }

        private int id;

        private float cap;

        private ModeCommande mode;

        private RegulateurAmure regulateurAmure;

        private Polaire currentPolaire;

        private List<Polaire> allPolaire;

        private Position pos;


        public void init(int id, List<Polaire> polaires, Position pos)
        {
            this.id = id;
            this.allPolaire = polaires;
            this.currentPolaire = null;
            this.pos = pos;
        }

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

        public void setCap(float cap)
        {
            this.cap = cap;
        }

        public float GetCapRegulateurAmure()
        {
            return this.regulateurAmure.Get_cap();
        }

        public Position GetPosition()
        {
            return this.pos;
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

        public void SetAvailablePolaire(List<Polaire> listPolaire)
        {
            this.allPolaire = listPolaire;
        }

        public List<Polaire> getAvailablePolaire()
        {
            return this.allPolaire;
        }

        public void SetCurrentPolaire(string name) {
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

        public Polaire GetCurrentPolaire()
        {
            return this.currentPolaire;
        }

        public List<Polaire> GetAllPolaire()
        {
            return allPolaire;
        }

    }
}