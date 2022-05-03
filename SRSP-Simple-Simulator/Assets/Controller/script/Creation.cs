using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;
using System;
using System.Globalization;
using UnityEngine.SceneManagement;
using Communication;
using Communication.DataProcessing;
using System.Net;
using Communication.DataProcessing.Json;

namespace Unityscript
{
    /// <summary>
    /// Script that initiate the model of the boat. It should be launch on the very first scene but not rerun on the scene.
    /// do not run again the "Debut" scene or you must destroy this before.
    /// It is the principale interface between information from model to interface and vis versa
    /// </summary>
    public class Creation : MonoBehaviour
    {
        public static Creation creation;
        public RaceModel model;
        public Observer obs;
        public BoatPhys boat;

        private void Awake()
        {
            creation = this;
            DontDestroyOnLoad(transform.gameObject);
            model = new RaceModel();
            //use pattern observer to link with the boat on unity and parameters of boat on model
            obs = new Observer(this);
            model.Attach(obs);
        }
        // Start is called before the first frame update
        void Start()
        {
            //load the next scene
            SceneManager.LoadScene("Scenes/Menu");
        }
        public void changeBoatInfo(float cap, float COG, float SOG)
        {
            //set parameters of boat 
            float accFactor = model.GetAccFactor();
            boat.cap = cap;
            boat.COG = COG;
            boat.SOG = SOG;
        }

        //All below methodes are methodes to link the model
        //They get called on other scripts that require action on the model via interface
        public void setCurrent(float currentspeed, float currentdir)
        {
            model.SetCurrent(currentspeed / 1.94384F, currentdir);
        }
        public void setWind(float windspeed, float winddir)
        {
            model.SetWind(windspeed / 1.94384F, winddir);
        }
        public void setWave(float waveampl, float wavedir, float wavelength)
        {
            model.SetWave(waveampl, wavedir, wavelength);
        }
        public void setFactorAcc(float factoracc)
        {
            model.SetFactor(factoracc);
        }

        public void switchCommande()
        {
            model.SwitchCommande();
        }
        public float showCap()
        {
            return model.getModelCap();
        }

        public float ShowRegulateurCap()
        {
            return model.getAllureCap();
        }

        /// <summary>
        /// change the cap of the model with n degres
        /// </summary>
        /// <param name="n">degres of incremental cap change</param>
        public void capChange(int n)
        {
            switch (n)
            {
                case -10:
                    model.IncrementCap(model.getCommandeMode(), PRace.DegreeIncrement.MinusTen);
                    break;
                case -1:
                    model.IncrementCap(model.getCommandeMode(), PRace.DegreeIncrement.MinusOne);
                    break;
                case +1:
                    model.IncrementCap(model.getCommandeMode(), PRace.DegreeIncrement.One);
                    break;
                case +10:
                    model.IncrementCap(model.getCommandeMode(), PRace.DegreeIncrement.Ten);
                    break;
            }
        }

        public float getFactorAcc()
        {
            return model.GetAccFactor();
        }

        public float getWindSpeed()
        {
            return model.getWindSpeed();
        }

        public float getWindDir()
        {
            return model.getWindDir();
        }
        public float getWaveAmpl()
        {
            return model.getWaveAmpl();
        }
        public float getWaveDir()
        {
            return model.getWaveDir();
        }
        public float getWaveLength()
        {
            return model.getWaveLength();
        }
        public float getWaterSpeed()
        {
            return model.getWaterSpeed();
        }
        public float getWaterDir()
        {
            return model.getWaterDir();
        }

        public float getSTW()
        {
            return model.getSTW();
        }

        public void setNMEA(int port, string ip)
        {
            model.setNMEA(port, ip);
        }
        public int getPortNMEA()
        {
            return model.getportNMEA();
        }
        public string getIpNMEA()
        {
            return model.getipNMEA();
        }

        public List<String> getBoatList(string ip, int port)
        {
            return model.getBoatList(ip, port);
        }

        public List<String> getPolars()
        {
            return model.getListPolaire();
        }
        public void setPolar(string polarName)
        {
            model.setPolaire(polarName);
        }
        public void setNullPolar()
        {
            model.setNoneCurrentPolar();
        }

        public void setWaypoint(float lat, float longi)
        {
            model.setPositionDeDepart(lat, longi);
        }

        public DateTime getClock()
        {
            return model.getTime();
        }
    }
}
