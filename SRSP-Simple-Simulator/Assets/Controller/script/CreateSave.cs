using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Unityscript
{
    /// <summary>
    /// Allow user to save current race with a inputfield to give it a name
    /// </summary>

    public class CreateSave : MonoBehaviour
    {
        public GameObject inputSave;
        string saveName;

        public void Save()
        {
            //get the input of the inputfield inputSaves
            saveName = inputSave.GetComponent<TMP_InputField>().text;
            Debug.Log(saveName);
            Creation.creation.model.Save(saveName);
        }
    }
}