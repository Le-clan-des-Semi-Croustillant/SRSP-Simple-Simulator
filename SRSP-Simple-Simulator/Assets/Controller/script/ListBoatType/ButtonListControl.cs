using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
namespace Unityscript
{
    /// <summary>
    /// Generate the button list of the boat type scene
    /// </summary>
    public class ButtonListControl : MonoBehaviour
    {
        [SerializeField]
        private GameObject buttonTemplate;

        private List<GameObject> buttons;

        private List<string> listBoatType;
        public SavedConfigReader.SavedConfig conf;
        public string currentBoat;



        /// <summary>
        /// initiate the list of gameobject button and the list on string for the list of boat type
        /// </summary>
        private void Start()
        {
            buttons = new List<GameObject>();
            listBoatType = new List<string>();
            SavedConfigReader test = new SavedConfigReader();
            conf = test.getConfig();
            GenerateList();
        }

        /// <summary>
        /// Called at the beguining of the boat selection scene and every time a refresh is called
        /// Destroy existing button then recreated from the boat type list get by  the race manager
        /// </summary>
        public void GenerateList()
        {
            if (buttons.Count > 0)
            {
                //for each existing button
                foreach (GameObject button in buttons)
                {
                    //destroy the button 
                    Destroy(button.gameObject);
                }
                
                buttons.Clear();
            }

            listBoatType = Creation.creation.getBoatList(conf.ipRM, conf.portRM);

            //for each boat type
            foreach (string boat in listBoatType)
            {
                //generate a button with the buttontemplate
                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);
                button.GetComponent<ButtonListButton>().SetText(boat);
                button.transform.SetParent(buttonTemplate.transform.parent, false);
                button.GetComponentInChildren<Button>().onClick.AddListener(() => SelectBoatType(boat, button));
                buttons.Add(button);
            }
        }
        public void SelectBoatType(string boatname,GameObject bu)
        {
            currentBoat = boatname;
            foreach (GameObject button in buttons)
            {
                button.GetComponentInChildren<Button>().image.color = Color.white;
            }
            bu.GetComponentInChildren<Button>().image.color = Color.green;
        }

        /// <summary>
        /// called when a button is clicked to load the boat type selected 
        /// move on the main scene to start a race
        /// </summary>
        /// <param name="myTextSring"></param>
        public void refresh()
        {
            SceneManager.LoadScene("Scenes/SelectionBoatType");
        }
        public void LoadBoatSelected()
        {
            //set the model with the current type boat selected
            Creation.creation.model.Set_Up(PRace.Mode.Entrainement, currentBoat);
            //run the next scene
            SceneManager.LoadScene("Scenes/Waypoint");
        }

    }
}
