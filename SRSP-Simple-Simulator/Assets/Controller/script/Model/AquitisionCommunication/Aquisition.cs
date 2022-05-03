
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using PRace;
using SimpleSimulator.AquitisionCommunication.Trame;
using Environement;
using UnityEngine;

namespace AquitisionCommunication{
    /// <summary>
    /// this classe manages the communication with QTVLM on OpenCPN
    /// </summary>
    public class Aquisition {

        /// <summary>
        /// Create an instance of Aquisition
        /// </summary>
        /// <param name="race">the race whose launch the communication</param>
        /// <param name="portQTVLM"></param>
        /// <param name="ipQTVLM"></param>
        /// <param name="portRM"></param>
        /// <param name="ipRM"></param>
        public Aquisition(PRace.Race race, int portQTVLM, string ipQTVLM, int portRM, string ipRM) {
            this.my_race = race;
            this.sender = new Sender();
            SavedConfigReader test = new SavedConfigReader();
            conf = test.getConfig();
            sender.port = conf.portQTVL;
            sender.ip = conf.ipQTVL;
            
        }
        private PRace.Race my_race;

        private Sender sender;

        public SavedConfigReader.SavedConfig conf;
        

        /// <summary>
        /// Set the ip and port to communicate with QTVLM
        /// </summary>
        /// <param name="port"></param>
        /// <param name="ip"></param>
        public void SetNMEA(int port, string ip)
        {
            this.sender.port = port;
            this.sender.ip = ip;
        }

        /// <summary>
        /// Return the port used to communicate with QTVML
        /// </summary>
        /// <returns></returns>
        public int getPortNMEA()
        {
            return this.sender.port;
        }

        /// <summary>
        /// Return the ip used to communicate with QTVML
        /// </summary>
        /// <returns></returns>
        public string getIpNMEA()
        {
            return this.sender.ip;
        }

        /// <summary>
        /// Sent information about the race to QTVLM
        /// </summary>
        /// <param name="condition">Environmentale conditions</param>
        /// <param name="SOG">Speed over ground</param>
        /// <param name="COG">course over ground</param>
        /// <param name="cap">heading</param>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude"longitude></param>
        /// <param name="date">date of the simulation</param>
        /// <param name="STW">speed throw water</param>
        /// <param name="AWS">speed throw air</param>
        /// <param name="AWA">angle throw air</param>
        public void sentPosition(Dictionary<Environement.Conditions,float> condition, float SOG ,float COG, float cap, Position.Coords latitude, Position.Coords longitude, DateTime date, float STW, float AWS, float AWA) {
            TrameNMEA trameNMEA = new TrameNMEA();
            TrameRMC rmc = trameNMEA.rmc;
            TrameVHW vhw = trameNMEA.vhw;
            TrameMWV mwv = trameNMEA.mwv;
            /*
            foreach (Conditions cond in condition.Keys)
            {
                switch (cond)
                {
                    case Conditions.WaveAmplitude:
                        break;
                    case Conditions.WaveLength:
                        break;
                    case Conditions.WaveDirection:
                        break;
                    case Conditions.CurrentSpeed:
                        break;
                    case Conditions.CurrentDirection:
                        break;
                    case Conditions.WindSpeed:
                        mwv.VitesseVent = condition[cond];
                        break;
                    case Conditions.WindDirection:
                        //by dany
                        //mwv.AngleVent = condition[cond];
                        break;
                    default:
                        break;
                }
            }
            */
            //4916.45,N = Latitude 49 deg. 16.45 min North
            mwv.AngleVent = AWA;
            mwv.VitesseVent = AWS;
            vhw.CapDegres = cap;
             //need STW
            vhw.VitBateauNoeud = STW; //need STW
            rmc.IndicateurLongitude = longitude.pos;
            rmc.Longitude = longitude.degre * 100 + (float)longitude.min + (float)longitude.sec/60;
            rmc.IndicateurLatitude = latitude.pos;
            float test = latitude.degre * 100 + (float)latitude.min + (float)latitude.sec / 60;
            rmc.Latitude = test;
            rmc.Heure = date;
            rmc.Date = date;

            rmc.Road = COG;
            rmc.Vitesse = SOG;
            sender.Send(trameNMEA);

        }

    }
}