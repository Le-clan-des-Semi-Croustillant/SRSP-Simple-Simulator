using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Unityscript
{
    /// <summary>
    /// Display information of the boat (cog/sog/hdg/stw)
    /// </summary>
    public class DisplayCadran : MonoBehaviour
    {
        public GameObject cog;
        public GameObject sog;
        public GameObject hdg;
        public GameObject stw;
        public GameObject date;

        public float COG;
        public int COGint;

        // Update is called once per frame
        
        void Update()
        {
            displayInfo();
        }
        public void displayInfo()
        {
            float tempcog = BoatPhys.bat.COG;
            COG = tempcog * (180f / Mathf.PI);
            COGint = (int)COG;


            //replace the text of the following game Object by the currant boat status
            cog.GetComponent<Text>().text = COGint.ToString();
            sog.GetComponent<Text>().text = parseFloat(BoatPhys.bat.SOG).ToString();
            hdg.GetComponent<Text>().text = BoatPhys.bat.cap.ToString();
            stw.GetComponent<Text>().text = parseFloat(Creation.creation.getSTW()).ToString();
            date.GetComponent<Text>().text = Creation.creation.getClock().ToString();
        }
        //get one float at one decimal
        public float parseFloat(float number)
        {
            int value;
            number = number * 10;
            value = (int)number;
            number = (float)value / 10f;
            return number;
        }
    }
}
