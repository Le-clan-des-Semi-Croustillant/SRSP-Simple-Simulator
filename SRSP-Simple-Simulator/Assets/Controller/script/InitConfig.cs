using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class InitConfig : MonoBehaviour
{
    //don't destroy on load
    //init object trame 
    public static InitConfig instance;
    //public TrameNMEA trame = new TrameNMEA();
    //public Sender send = new Sender();


    private void Awake() //keep instance of the script to keep instance of object
    {
        instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //send.ip = "0";
        //send.port = 0;
    }

    private void Update()
    {
        Debug.Log("Show config");
       // Debug.Log(send.ip);
       //Debug.Log(send.port);
        Thread.Sleep(100);
    }

}