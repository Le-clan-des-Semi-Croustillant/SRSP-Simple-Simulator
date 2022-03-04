using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetAcc : MonoBehaviour
{
    public GameObject inputAcc;
    public void setacc()
    {
        float acc = float.Parse(inputAcc.GetComponent<TMP_InputField>().text.Replace(".", ","));
        Creation.creation.setFactorAcc(acc);
    }
}
