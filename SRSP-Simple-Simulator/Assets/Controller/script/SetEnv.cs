using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Model;
using TMPro;

namespace Unityscript
{
    /// <summary>
    /// Allow user to change environment parameters with inputfields from interface
    /// </summary>
    public class SetEnv : MonoBehaviour
    {
        public GameObject windSpeed;
        public GameObject windDir;

        public GameObject waveAmpl;
        public GameObject waveDir;
        public GameObject waveLength;

        public GameObject waterSpeed;
        public GameObject waterDir;
        public EnvPanel panel;
        //all below methodes get the input of a user and update the parameters of the model with it
        public void setWind() //on click ok event
        {
            float windspeed = float.Parse(windSpeed.GetComponent<TMP_InputField>().text.Replace(".", ","));
            float winddir = float.Parse(windDir.GetComponent<TMP_InputField>().text.Replace(".", ","));
            Creation.creation.setWind(windspeed, winddir);
        }
        public void setWave()
        {
            float waveamp = float.Parse(waveAmpl.GetComponent<TMP_InputField>().text.Replace(".", ","));
            float wavedir = float.Parse(waveDir.GetComponent<TMP_InputField>().text.Replace(".", ","));
            float wavelength = float.Parse(waveLength.GetComponent<TMP_InputField>().text.Replace(".", ","));
            Creation.creation.setWave(waveamp, wavedir, wavelength);
            //Debug.Log(waveAmpl.text);
            //Debug.Log(waveDir.text);
            //Debug.Log(waveLength.text);
        }
        public void setWater()
        {
            float waterspeed = float.Parse(waterSpeed.GetComponent<TMP_InputField>().text.Replace(".", ","));
            float waterdir = float.Parse(waterDir.GetComponent<TMP_InputField>().text.Replace(".", ","));
            Creation.creation.setCurrent(waterspeed, waterdir);
        }
    }
}
