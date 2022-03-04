using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;
//using SimpleSimulator.AquitisionCommunication.Trame;

public class Initialisation : MonoBehaviour
{
    
    public Transform Boat; //object boat unity
    public Vector3 rotation = new Vector3(0f, 0f, 1f); //degres de rotation par deltaT time
    public float cap = 0f;
    public InitConfig config;
    private void Start()
    {
        config = FindObjectOfType<InitConfig>();
        //Debug.Log(config.send.ip);
        //Debug.Log(config.send.port);
        //send.ip = "127.0.0.1";
        //send.port = 10114;
    }

    // Update is called once per frame
    void Update()
    { 
        //NMEA trame cap update
        //config.trame.vhw.CapDegres = cap;
        //send trame to QTVLM
        //config.send.Send(config.trame);
        //rotation GameObject
        Boat.transform.Rotate(rotation);
        cap += 1f;
        Thread.Sleep(100);
    }
}
