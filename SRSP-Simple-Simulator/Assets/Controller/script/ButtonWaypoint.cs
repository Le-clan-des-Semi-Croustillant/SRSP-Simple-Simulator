using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.IO;
using System;
using System.Xml;

namespace Unityscript
{
    /// <summary>
    /// Manages the scene waypoint to display waypoints on the "Waypoints.gpx" file 
    /// And allow to select a starting point
    /// </summary>
    
    public class ButtonWaypoint : MonoBehaviour
    {
        List<string> listWaypoint;
        public int indexWp = 0;
        List<string> longitude;
        List<string> latitude;

        [SerializeField]
        private GameObject buttonTemplate;
        public string selectedWaypoint = null;

        private List<GameObject> buttons;

        private void Start()
        {
            buttons = new List<GameObject>();
            listWaypoint = new List<string>();
            longitude = new List<string>();
            latitude = new List<string>();
            
            GenerateList();
        }

        public void GenerateList()
        {
            //read the 
            using (XmlReader reader = XmlReader.Create("./Assets/Waypoints.gpx"))
            {
                reader.ReadToFollowing("wpt");
                do
                {
                    reader.MoveToFirstAttribute();
                    latitude.Add(reader.Value);
                    reader.MoveToNextAttribute();
                    longitude.Add(reader.Value);
                    reader.ReadToFollowing("name");
                    listWaypoint.Add(reader.ReadElementContentAsString());
                } while (reader.ReadToFollowing("wpt"));
                //Console.WriteLine(reader);
            }
            //generate as many buttons as waypoints
            foreach (string s in listWaypoint)
            {
                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);
                button.GetComponent<ButtonListButton>().SetText(s);
                button.transform.SetParent(buttonTemplate.transform.parent, false);
                button.GetComponentInChildren<Button>().onClick.AddListener(() => Selectedwaypoint(s, button));
                buttons.Add(button);
            }
        }

        private void Selectedwaypoint(string s, GameObject bu)
        {
            //get the index of the button selected
            indexWp = buttons.IndexOf(bu);
            Debug.Log(indexWp);
            selectedWaypoint = s;
            //reset the color of the buttons list
            foreach (GameObject button in buttons)
            {
                button.GetComponentInChildren<Button>().image.color = Color.white;
            }
            //set the given one on green color
            bu.GetComponentInChildren<Button>().image.color = Color.green;
        }

        public void LoadWaypointOnClick()
        {
            //parse the string to float
            float lat = float.Parse(latitude.ElementAt(indexWp).Replace(".", ","));
            float longi = float.Parse(longitude.ElementAt(indexWp).Replace(".", ","));

            //setloadwaypoint
            Creation.creation.setWaypoint(lat, longi);
            SceneManager.LoadScene("Scenes/Main");
        }
    }
}
