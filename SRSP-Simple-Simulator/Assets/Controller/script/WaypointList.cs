using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System;
using System.Xml;
using System.Threading;

public class WaypointList : MonoBehaviour
{
    public int numeroWp = 1;

    List<string> longitude = new List<string>();
    List<string> latitude = new List<string>();
    List<string> name = new List<string>();
    void Start()
    {
        
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
                name.Add(reader.ReadElementContentAsString());
            } while (reader.ReadToFollowing("wpt"));
            Console.WriteLine(reader);
        }

    }
}
