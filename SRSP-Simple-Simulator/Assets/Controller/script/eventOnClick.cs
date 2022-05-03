using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unityscript
{
    /// <summary>
    /// Main script to manage scene transition
    /// </summary>
    public class eventOnClick : MonoBehaviour
    {
        public void exitApp()
        {
            Application.Quit();
        }
        public void continueRace()
        {
            SceneManager.LoadScene("Scenes/Backups");
        }
        public void startNewGame()
        {
            SceneManager.LoadScene("Scenes/Mode");
        }
        public void Menu()
        {
            SceneManager.LoadScene("Scenes/Menu");
        }

        public void configIPfromMode()
        {
            SceneManager.LoadScene("Scenes/Initialisation");
        }

        public void ConfigIpFromMenu()
        {
            SceneManager.LoadScene("Scenes/ConfigFromMenu");
        }

        public void loadRMBoatList()
        {
            SceneManager.LoadScene("Scenes/SelectionBoatType");
        }

        public void initVerify()
        {
            SceneManager.LoadScene("Scenes/Initialisation");
        }
        public void waypointLoadScene()
        {
            SceneManager.LoadScene("Scenes/Waypoint");
        }
        public void loadDocumentation()
        {
            Application.OpenURL("https://le-clan-des-semi-croustillant.github.io/SRSP-Simple-Simulator/");
        }
    }
}
