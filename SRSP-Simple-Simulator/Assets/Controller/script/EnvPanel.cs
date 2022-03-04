using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvPanel : MonoBehaviour
{

    public GameObject PanelWind;
    public GameObject PanelWave;
    public GameObject PanelWater;
    
    public void showPanelWind()
    {
        PanelWind.gameObject.SetActive(true);
        PanelWave.gameObject.SetActive(false);
        PanelWater.gameObject.SetActive(false);
    }

    public void showPanelWave()
    {
        PanelWind.gameObject.SetActive(false);
        PanelWave.gameObject.SetActive(true);
        PanelWater.gameObject.SetActive(false);
    }
    public void showPanelWater()
    {
        PanelWind.gameObject.SetActive(false);
        PanelWave.gameObject.SetActive(false);
        PanelWater.gameObject.SetActive(true);
    }
    public void closePanelWind()
    {
        PanelWind.gameObject.SetActive(false);
    }
    public void closePanelWave()
    {
        PanelWave.gameObject.SetActive(false);
    }
    public void closePanelWater()
    {
        PanelWater.gameObject.SetActive(false);
    }

    public void pressfone()
    {
        if (PanelWind.activeSelf)
        {
            closePanelWind();
        }
        else
        {
            showPanelWind();
        }
    }

    public void pressftwo()
    {
        if (PanelWave.activeSelf)
        {
            closePanelWave();
        }
        else
        {
            showPanelWave();
        }
    }

    public void pressfthree()
    {
        if (PanelWater.activeSelf)
        {
            closePanelWater();
        }
        else
        {
            showPanelWater();
        }
    }
}
