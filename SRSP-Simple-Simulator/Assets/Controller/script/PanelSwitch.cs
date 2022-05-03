using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Unityscript
{
    /// <summary>
    /// Manage the configuration tab panel
    /// </summary>
    public class PanelSwitch : MonoBehaviour
    {

        public GameObject PanelQTVLM;
        public GameObject PanelRM;
        public GameObject PanelLang;

        //Set to true its panel and other to false
        //because one panel can be display at a time
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
}
