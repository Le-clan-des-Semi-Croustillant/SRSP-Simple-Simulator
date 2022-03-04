using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;
using System;
using System.Globalization;

public class Creation : MonoBehaviour
{
    public static Creation creation;
    public BoatPhys boat;
    public RaceModel model;
    public Observer obs;
    // Start is called before the first frame update
    private void Awake()
    {
        creation = this;
        DontDestroyOnLoad(transform.gameObject);

    }
    void Start()
    {
        boat = FindObjectOfType<BoatPhys>();
        model = new RaceModel("model.json");
        obs = new Observer(this);
        model.Attach(obs);
        model.GetRace().GetBoat().setCap(0);
        model.GetRace().GetEnvironment().UpdateCurrent(0, 0);
        model.GetRace().SetAccFactor(1);
        model.Run();

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
        model.SetCurrent(currentspeed, currentdir); 
    }
    public void setWind(float windspeed, float winddir)
    {
        model.SetWind(windspeed, winddir);
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
}
