using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Unityscript
{
    /// <summary>
    /// Allow cap to be change with input 
    /// </summary>
    public class Controler : MonoBehaviour
    {
        public Text captext;
        public Text capAllureText;

        public void Start()
        {
            DisplayCap();
        }

        public void DisplayCap()
        {
            captext.text = Creation.creation.showCap().ToString();
            capAllureText.text = Creation.creation.ShowRegulateurCap().ToString();
        }
        /// <summary>
        /// change cap with a n degres 
        /// </summary>
        /// <param name="n">degres of incremental cap change</param>
        public void changeCap(int n)
        {
            Creation.creation.capChange(n);
            DisplayCap();
        }

    }
}
