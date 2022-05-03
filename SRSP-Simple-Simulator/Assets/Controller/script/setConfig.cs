using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unityscript
{
    /// <summary>
    /// Script that manage the configuration with the 
    /// -NMEA port / IP
    /// -RM port / IP
    /// -language
    /// </summary>
    public class setConfig : MonoBehaviour
    {
        public SavedConfigReader.SavedConfig conf;
        public GameObject inputNMEA;
        public GameObject inputIPNMEA;
        public GameObject inputRM;
        public GameObject inputIPRM;
        public TMP_Dropdown lang;

        void Start()
        {
            SavedConfigReader test = new SavedConfigReader();
            conf = test.getConfig();
            ShowConfig();

        }

        public void SetNMEA()
        {
            int port = int.Parse(inputNMEA.GetComponent<TMP_InputField>().text);
            string ip = inputIPNMEA.GetComponent<TMP_InputField>().text;
            conf.Update(ipQTVL: ip, portQTVL: port);
        }
        public void SetRM()
        {
            int port = int.Parse(inputRM.GetComponent<TMP_InputField>().text);
            string ip = inputIPRM.GetComponent<TMP_InputField>().text;
            conf.Update(ipRM: ip, portRM: port);
        }
        public void SetLang(TMP_Dropdown lang)
        {
            if (lang.value == 0)
            {
                Debug.Log(lang.value);
                conf.Update(language: 1);
            }
            if (lang.value == 1)
            {
                Debug.Log(lang.value);
                conf.Update(language: 2);
            }
        }

        /// <summary>
        /// Display initial configuration at start
        /// </summary>
        public void ShowConfig()
        {
            inputNMEA.GetComponent<TMP_InputField>().text = conf.portQTVL.ToString();
            inputIPNMEA.GetComponent<TMP_InputField>().text = conf.ipQTVL;
            inputRM.GetComponent<TMP_InputField>().text = conf.portRM.ToString();
            inputIPRM.GetComponent<TMP_InputField>().text = conf.ipRM;
            lang.value = conf.language - 1;
            lang.onValueChanged.AddListener(delegate
            {
                SetLang(lang);
            });

        }
    }
}
