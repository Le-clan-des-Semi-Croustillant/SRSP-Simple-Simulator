using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unityscript
{
    /// <summary>
    /// Display value of all parameters in main scene at the start
    /// </summary>
    public class ShowValue : MonoBehaviour
    {
        public GameObject inputAcc;

        public GameObject windSpeed;
        public GameObject windDir;

        public GameObject waveAmpl;
        public GameObject waveDir;
        public GameObject waveLength;

        public GameObject waterSpeed;
        public GameObject waterDir;

        void Start()
        {
            ShowInitValue();
        }

        /// <summary>
        /// Get values from model and display it on GameObject in main scene
        /// </summary>
        public void ShowInitValue()
        {

            float windS = Creation.creation.getWindSpeed();

            float windD = Creation.creation.getWindDir();
            float waveA = Creation.creation.getWaveAmpl();
            float waveD = Creation.creation.getWaveDir();
            float waveL = Creation.creation.getWaveLength();
            float waterS = Creation.creation.getWaterSpeed();
            float waterD = Creation.creation.getWaterDir();

            float acc = Creation.creation.getFactorAcc();
            inputAcc.GetComponent<TMP_InputField>().text = acc.ToString();

            windSpeed.GetComponent<TMP_InputField>().text = windS.ToString();

            windDir.GetComponent<TMP_InputField>().text = windD.ToString();
            waveAmpl.GetComponent<TMP_InputField>().text = waveA.ToString();
            waveDir.GetComponent<TMP_InputField>().text = waveD.ToString();
            waveLength.GetComponent<TMP_InputField>().text = waveL.ToString();
            waterSpeed.GetComponent<TMP_InputField>().text = waterS.ToString();
            waterDir.GetComponent<TMP_InputField>().text = waterD.ToString();

        }

    }
}
