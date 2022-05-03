using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Model;


namespace Unityscript
{
    /// <summary>
    /// Manage the visual of the boat according to the model information.
    /// the boat rigidbody has been attach to the model before.
    /// </summary>
    public class BoatPhys : MonoBehaviour
    {
        public static BoatPhys bat;

        //our boat is a rigib body on unity
        public Rigidbody2D boat;
        public Vector2 velocity = new Vector2(0f, 0f);

        public float cap;
        public float COG;
        public float SOG;

        private void Awake()
        {
            bat = this;
        }
        void Update()
        {
            float x, y;
            //set the vector with x and y 
            y = Mathf.Cos(this.COG) * this.SOG;
            x = Mathf.Sin(this.COG) * this.SOG;
            velocity.x = x;
            velocity.y = y;
            //apply force to the boat
            boat.velocity = velocity;
            //apply rotation to the boat on unity the rotation is clockwise so we have to use negative cap
            boat.SetRotation(-(this.cap));

        }
    }
}
