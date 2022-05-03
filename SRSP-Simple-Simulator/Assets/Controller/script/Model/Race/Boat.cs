
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Communication.DataProcessing.Json;


namespace PRace
{
    /// <summary>
    /// This represent a boat
    /// </summary>
    public class Boat {

        /// <summary>
        /// create au boat instance
        /// </summary>
        public Boat()
        {
            this.regulateurAmure = new RegulateurAmure(this);
            this.pos = new Position(90,0);
        }

        /// <summary>
        /// create au boat instance based on the the input boat type
        /// </summary>
        /// <param name="selectedBoatType"></param>
        public Boat(BoatType selectedBoatType)
        {
            this.regulateurAmure = new RegulateurAmure(this);
            this.pos = new Position(90, 0);
        }
        private int id;

        private float cap;

        private Race race;

        private ModeCommande commande = ModeCommande.cap;

        private RegulateurAmure regulateurAmure;

        private Polaire currentPolaire;

        private List<Polaire> allPolaire;

        private Position pos;

        /// <summary>
        /// Initialise the 'allPolaire', id and pos attribut
        /// </summary>
        /// <param name="id"></param>
        /// <param name="polaires"></param>
        /// <param name="pos"></param>
        public void init(int id, List<Polaire> polaires, Position pos, Race race)
        {
            this.id = id;
            this.allPolaire = polaires;
            this.currentPolaire = null;
            this.pos = pos;
            this.race = race;
        }

        public int GetId()
        {
            return id;
        }



        public float getCap()
        {
            return this.cap;
        }

        /// <summary>
        /// set the boat heading
        /// </summary>
        /// <param name="cap">this value as to be in radient</param>
        public void setCap(float cap)
        {
            this.cap = (cap + 360) % 360;
        }

        public float getCapRad()
        {
            return this.cap / 360 * 2 * (float)Math.PI;
        }

        public void setCapRad(float cap)
        {
            this.cap = (cap + 2 * (float)Math.PI) % 2 * (float)Math.PI;
            this.cap = cap / 2 / (float)Math.PI * 360;
        }

        /// <summary>
        /// return the value of the cap of the attribut 'regulateurAmure'
        /// </summary>
        /// <returns>the angle is in randiant</returns>
        public float GetCapRegulateurAmure()
        {
            return this.regulateurAmure.Get_cap();
        }

        public Position GetPosition()
        {
            return this.pos;
        }


        public void SetModeCommande(ModeCommande commande)
        {
            this.commande = commande;
            if (commande == ModeCommande.RegulateurAmure)
            {
                var env = race.GetEnvironment().getEnvState();
                float wd;
                env.TryGetValue(Environement.Conditions.WindDirection, out wd);
                regulateurAmure.SetCap(this.cap - wd);
            }
        }

        /// <summary>
        /// If the attrubit commande is 'cap' switch to 'RegulateurAmure'.
        /// If the attrubit commande is 'RegulateurAmure' switch to 'cap'.
        /// </summary>
        public void switchCommande()
        {
            switch (commande)
            {
                case ModeCommande.RegulateurAmure:
                    this.commande = ModeCommande.cap;
                    break;
                case ModeCommande.cap:
                    this.commande = ModeCommande.RegulateurAmure;
                    var env = race.GetEnvironment().getEnvState();
                    float wd;
                    env.TryGetValue(Environement.Conditions.WindDirection, out wd);
                    regulateurAmure.SetCap(this.cap - wd);
                    break;
                default:
                    break;
            }
        }

        public ModeCommande GetModeCommande()
        {
            return this.commande;
        }

        /// <summary>
        /// If the attrubit commande is 'RegulateurAmure' change the heading of the boat (attribut cap)
        /// to keep the windward course set in regulateurAmure
        /// </summary>
        /// <param name="env"></param>
        public void UpdateCap(Environement.Environment env)
        {
            switch (this.commande )
            {
                case ModeCommande.RegulateurAmure:
                    this.regulateurAmure.Update_cap(env);
                    break;
                case ModeCommande.cap:
                    break;
                default:
                    break;
            }
        }

        public void setPosition(Position pos)
        {
            this.pos = pos;
        }


        /// <summary>
        /// set 'allPolaire' attribut
        /// </summary>
        /// <param name="listPolaire"></param>
        public void SetAvailablePolaire(List<Polaire> listPolaire)
        {
            this.allPolaire = listPolaire;
        }

        /// <summary>
        /// getter for 'allPolaire' attribut
        /// </summary>
        /// <returns></returns>
        public List<Polaire> getAvailablePolaire()
        {
            return this.allPolaire;
        }

        /// <summary>
        /// Increment the cap of the active mode ('commande' attribut)
        /// </summary>
        /// <param name="commande"></param>
        /// <param name="degre"></param>
        public void IncrementCap(ModeCommande commande, DegreeIncrement degre)
        {
            switch (commande)
            {
                case ModeCommande.RegulateurAmure:
                    this.regulateurAmure.SetCap(regulateurAmure.Get_cap() + (float)degre);
                    break;
                case ModeCommande.cap:
                    this.setCap(cap + (float)degre);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// If a polar with the attribut name corresponding to the input name exist in the attribut 'allPolaire',
        /// set it as the current polar ('currentPolaire' attribut)
        /// </summary>
        /// <param name="name"></param>
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

        public float GetAllureCap()
        {
            return this.regulateurAmure.Get_cap();
        }

        /// <summary>
        /// Set the attribut 'currentPolaire' to null
        /// </summary>
        public void setNullCurrentPolar()
        {
            this.currentPolaire = null;
        }
    }
}