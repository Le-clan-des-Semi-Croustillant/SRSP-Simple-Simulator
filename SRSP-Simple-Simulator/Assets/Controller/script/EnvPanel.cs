using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Manage panels visibility on the "main scene" 
/// </summary>
public class EnvPanel : MonoBehaviour
{

    public GameObject PanelWind;
    public GameObject PanelWave;
    public GameObject PanelWater;
    public GameObject PanelSave;

    //All methodes below allow to set visible/inactive Panels
    public void showPanelSave()
    {
        PanelSave.gameObject.SetActive(true);
    }
    
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

    public void closePanelSave()
    {
        PanelSave.gameObject.SetActive(false);
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
    /// <summary>
    /// Allow user to press F1 to display wind panel 
    /// </summary>
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

    /// <summary>
    /// Allow user to press F2 to display wave panel
    /// </summary>
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

    /// <summary>
    /// Allow user to press F3 to display current panel
    /// </summary>
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
