using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Model;
public class BoatPhys : MonoBehaviour
{

    public Rigidbody2D boat;
    public Vector2 velocity = new Vector2(0f, 0f);

    public float cap;
    public float COG;
    public float SOG;

    private void Start()
    { 
    }
    void Update()
    {
        float x, y;
        y = Mathf.Cos(this.COG) * this.SOG;
        x = Mathf.Sin(this.COG) * this.SOG;
        velocity.x = x;
        velocity.y = y;
        boat.velocity = velocity;
        //boat.AddForce(velocity);
        boat.SetRotation(-(this.cap));
       
    }


}
