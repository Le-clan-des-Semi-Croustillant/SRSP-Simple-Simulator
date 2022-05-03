using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Unityscript
{
    /// <summary>
    /// Allow display and selection of polars attach to the boat selected earlier
    /// </summary>
    public class PolarSelection : MonoBehaviour
    {
        public List<string> listPolar;

        [SerializeField]
        private GameObject buttonTemplate;
        public GameObject selectedButton;

        private List<GameObject> buttons;
        private void Start()
        {
            buttons = new List<GameObject>();
            listPolar = new List<string>();
            GenerateList();
        }

        /// <summary>
        /// Display as many button as polars
        /// </summary>
        public void GenerateList()
        {
            listPolar = Creation.creation.getPolars(); //change to polar
            foreach (string s in listPolar)
            {
                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);
                button.GetComponent<ButtonListButton>().SetText(s);
                button.transform.SetParent(buttonTemplate.transform.parent, false);
                button.GetComponentInChildren<Button>().onClick.AddListener(() => LoadPolarOnClick(s, button));
                buttons.Add(button);
            }
        }

        /// <summary>
        /// Load the polar selected
        /// </summary>
        /// <param name="s">name of the polar selected</param>
        /// <param name="bu">button selected</param>
        public void LoadPolarOnClick(string s, GameObject bu)
        {
            SelectedPolar(bu);
            Creation.creation.setPolar(s);
            Debug.Log(s);
        }
        /// <summary>
        /// Highlight the button selected of the polar to green
        /// </summary>
        /// <param name="bu"></param>
        private void SelectedPolar(GameObject bu)
        {
            resetButton();
            bu.GetComponentInChildren<Button>().image.color = Color.green;
        }

        /// <summary>
        /// reset the color of the buttons
        /// </summary>
        private void resetButton()
        {
            foreach (GameObject button in buttons)
            {
                button.GetComponentInChildren<Button>().image.color = Color.white;
            }
        }
        /// <summary>
        /// change the sails to none
        /// </summary>
        public void setNullCurrentPolar()
        {
            resetButton();
            Creation.creation.setNullPolar();
        }
    }
}
