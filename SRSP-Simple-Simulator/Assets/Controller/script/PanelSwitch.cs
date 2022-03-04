using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSwitch : MonoBehaviour
{
    
    public GameObject PanelQTVLM;
    public GameObject PanelRM;
    public GameObject PanelLang;

    public void showPanelQTVLM()
    {
        PanelQTVLM.gameObject.SetActive(true);
        PanelRM.gameObject.SetActive(false);
        PanelLang.gameObject.SetActive(false);
    }
    public void showPanelRM()
    {
        PanelQTVLM.gameObject.SetActive(false);
        PanelRM.gameObject.SetActive(true);
        PanelLang.gameObject.SetActive(false);
    }
    public void showPanelLang()
    {
        PanelQTVLM.gameObject.SetActive(false);
        PanelRM.gameObject.SetActive(false);
        PanelLang.gameObject.SetActive(true);
    }

}
