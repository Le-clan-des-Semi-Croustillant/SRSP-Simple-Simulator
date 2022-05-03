using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

namespace Unityscript
{
    /// <summary>
    /// Allow factor of acceleration to be change acording to input user
    /// </summary>
    public class SetAcc : MonoBehaviour
    {
        public GameObject inputAcc;
        public void setacc()
        {
            try
            {
                //get the input of the user on the inputfield "inputAcc" and replace the "." by a "," to allow changement
                float acc = float.Parse(inputAcc.GetComponent<TMP_InputField>().text.Replace(".", ","));
                //don't let a 0 acceleration be displayed
                if (acc != 0)
                {
                    Creation.creation.setFactorAcc(acc);
                }
            }
            catch (FormatException exp) { }

        }
    }
}