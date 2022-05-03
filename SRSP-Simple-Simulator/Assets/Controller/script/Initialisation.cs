using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;
using SimpleSimulator.AquitisionCommunication.Trame;

namespace Unityscript
{
    /// <summary>
    /// Manage the sequence of initialisation
    /// The Transform boat is turning and is sending to the corresponding port and ip NMEA trames
    /// </summary>
    public class Initialisation : MonoBehaviour
    {
        public Transform Boat; //object boat unity
        public Vector3 rotation = new Vector3(0f, 0f, 1f); //degres of rotation by deltaT time
        public float cap = 0f;
        public Sender send;
        public TrameNMEA trame;
        public SavedConfigReader.SavedConfig conf;
        private void Start()
        {
            //Debug.Log(config.send.ip);
            //Debug.Log(config.send.port);
            SavedConfigReader test = new SavedConfigReader();
            conf = test.getConfig();
            trame = new TrameNMEA();
            send = new Sender();
            send.ip = conf.ipQTVL;
            send.port = conf.portQTVL;
        }

        void Update()
        {
            //NMEA trame cap update
            trame.vhw.CapDegres = cap;
            //send trame to QTVLM
            send.Send(trame);
            //rotation GameObject
            Boat.transform.Rotate(-rotation);
            cap += 1f;
            Thread.Sleep(100);
        }
    }
}
