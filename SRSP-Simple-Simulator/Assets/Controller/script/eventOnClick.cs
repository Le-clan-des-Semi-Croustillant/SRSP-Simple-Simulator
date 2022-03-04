using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class eventOnClick : MonoBehaviour
{
    public void exitApp()
    {
        Application.Quit();
    }
    public void continueRace()
    {
        SceneManager.LoadScene(1);
    }
    public void startNewGame()
    {
        SceneManager.LoadScene(2);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void configIPfromMode()
    {
        SceneManager.LoadScene(4);
    } 

    public void ConfigIpFromMenu()
    {
        SceneManager.LoadScene(3);
    }
    public void initVerify()
    {
        SceneManager.LoadScene("Scenes/Initialisation");
    }

    public void loadDocumentation()
    {
        Application.OpenURL("https://le-clan-des-semi-croustillant.github.io/SRSP-Simple-Simulator/"); 
    }
}
