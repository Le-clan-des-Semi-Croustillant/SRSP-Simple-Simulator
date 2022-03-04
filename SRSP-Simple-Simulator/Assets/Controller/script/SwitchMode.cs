using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMode : MonoBehaviour
{
    public GameObject PanelCap;
    public GameObject PanelWind;
    public bool isActive = true;
    // Start is called before the first frame update
    public void showCappanel()
    {
        PanelCap.gameObject.SetActive(true);
        PanelWind.gameObject.SetActive(false);

        Creation.creation.switchCommande();
        //switchmode switch mode link model
    }

    public void showWindpanel()
    {
        PanelCap.gameObject.SetActive(false);
        PanelWind.gameObject.SetActive(true);
        Creation.creation.switchCommande();
        //switch mode link model
    }
    public void tabpress()
    {
        if (isActive)
        {
            showWindpanel();
            isActive = !isActive;
        }
        else
        {
            showCappanel();
            isActive = !isActive;
        }
    }
}