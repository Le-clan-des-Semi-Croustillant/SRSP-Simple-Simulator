using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setConfig : MonoBehaviour
{
    // Start is called before the first frame update
    public InitConfig config = InitConfig.instance;
    public GameObject inputNMEA;
    public GameObject inputIP;

    /*
    void Start()
    {
       config = FindObjectOfType<InitConfig>();
       config = GameObject.Find("Init").GetComponent<InitConfig>();
    }
    */


    public void SetConfig() //on ok button //link to model
    {
       //config.send.port = Int32.Parse(inputNMEA.GetComponent<Text>().text);
       //config.send.ip = inputIP.GetComponent<Text>().text;
    }
}
