using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;
using System.IO;
using System;

namespace Unityscript
{
    /// <summary>
    /// Manage the "save selection" scene 
    /// </summary>

    public class ButtonsSavesControl : MonoBehaviour
    {
        public List<string> listSaves;

        [SerializeField]
        private GameObject buttonTemplate;
        public string selectedSaves = null;

        private List<GameObject> buttons;

        private void Start()
        {
            buttons = new List<GameObject>();
            listSaves = new List<string>();
            GenerateList();
        }

        /// <summary>
        /// Initiates as many button as existing saves in folder
        /// </summary>
        public void GenerateList()
        {
            listSaves = Creation.creation.model.ListSavePath().ToList();
            string saveDir = Directory.GetCurrentDirectory() + "/Saves";

            foreach (string s in listSaves)
            {
                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);
                //get the sub string of the save to be display 
                string sub = s.Substring(saveDir.Length);
                sub = sub.Trim(new Char[] { '/', '\\' });
                button.GetComponent<ButtonListButton>().SetText(sub);
                button.transform.SetParent(buttonTemplate.transform.parent, false);
                //add a listener that get trigger when the button is click (it calls SelectedSaves on click)
                button.GetComponentInChildren<Button>().onClick.AddListener(() => SelectedSaves(s, button));
                buttons.Add(button);
            }
        }

        /// <summary>
        /// Highlight save selected in green
        /// </summary>
        /// <param name="s">save name selected</param>
        /// <param name="bu">button selected</param>
        private void SelectedSaves(string s, GameObject bu)
        {
            selectedSaves = s;
            foreach (GameObject button in buttons)
            {
                button.GetComponentInChildren<Button>().image.color = Color.white;
            }
            bu.GetComponentInChildren<Button>().image.color = Color.green;
        }

        /// <summary>
        /// Load the currentSave and load the main scene when ok pressed
        /// </summary>
        public void LoadSavesOnClick()
        {
            SavedConfigReader test = new SavedConfigReader();
            SavedConfigReader.SavedConfig conf = test.getConfig();
            Creation.creation.model.Set_Up(path: selectedSaves, portQTVLM: conf.portQTVL, ipQTVLM: conf.ipQTVL);
            SceneManager.LoadScene("Scenes/Main");
        }

    }
}