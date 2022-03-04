using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controler : MonoBehaviour
{
    //public BoatPhys boat;
    //public Manager manager;
    public Text captext;

    public void Start()
    {
        //manager = FindObjectOfType<Manager>();
        DisplayCap();
    }

    public void DisplayCap()
    {
       captext.text = Creation.creation.showCap().ToString();
    }
    
    public void changeCap(int n)
    {
        //manager.boat.setCap(manager.boat.getCap() + n);
        Creation.creation.capChange(n);
        DisplayCap();
    }

}
