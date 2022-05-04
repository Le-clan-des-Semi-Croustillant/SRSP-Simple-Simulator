using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;
using System;
using System.Globalization;
using UnityEngine.SceneManagement;

public class Creation : MonoBehaviour
{
    public static Creation creation;
    public RaceModel model;
    public Observer obs;
    public BoatPhys boat;
    // Start is called before the first frame update
    private void Awake()
    {
        creation = this;
        DontDestroyOnLoad(transform.gameObject);
        model = new RaceModel();
        obs = new Observer(this);
        model.Attach(obs);
        /*
        boat = FindObjectOfType<BoatPhys>();
        model.GetRace().GetBoat().setCap(0);
        model.GetRace().GetEnvironment().UpdateCurrent(0, 0);
        model.GetRace().SetAccFactor(1);
        model.Run();
        */ //test run on main scene
    }

    void Start()
    {
        SceneManager.LoadScene(0);
    }
    public void changeBoatInfo(float cap, float COG, float SOG)
    {
        float accFactor = model.GetAccFactor();
        boat.cap = cap;
        boat.COG = COG;
        boat.SOG = SOG/accFactor;
    }

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
}
