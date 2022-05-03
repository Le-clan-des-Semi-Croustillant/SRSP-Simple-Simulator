using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Unityscript
{

    /// <summary>
    /// Allow user to switch in between heading mode and wind mode
    /// </summary>
    public class SwitchMode : MonoBehaviour
    {
        public GameObject PanelCap;
        public GameObject PanelWind;
        public bool isActive = true;
        public Text captext;
        public Text capAllureText;

        private void Start()
        {
            captext.text = Creation.creation.showCap().ToString();
            capAllureText.text = Creation.creation.ShowRegulateurCap().ToString();
        }
        public void showCappanel()
        {
            captext.text = Creation.creation.showCap().ToString();
            PanelCap.gameObject.SetActive(true);
            PanelWind.gameObject.SetActive(false);
            Creation.creation.switchCommande();
        }

        public void showWindpanel()
        {
            capAllureText.text = Creation.creation.ShowRegulateurCap().ToString();
            PanelCap.gameObject.SetActive(false);
            PanelWind.gameObject.SetActive(true);
            Creation.creation.switchCommande();
        }
        /// <summary>
        /// Allow user to switch with pressing TAB
        /// </summary>
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
}