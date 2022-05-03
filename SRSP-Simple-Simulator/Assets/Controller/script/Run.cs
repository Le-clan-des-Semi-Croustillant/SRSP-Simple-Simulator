using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unityscript
{
    /// <summary>
    /// Script that attach the boat to the model
    /// then run the model to start a race
    /// This script should be run at the beguining of the "main scene" 
    /// </summary>
    public class Run : MonoBehaviour
    {
        private void Awake()
        {
            //attach boat to the BoatPhys script
            Creation.creation.boat = FindObjectOfType<BoatPhys>();
            //run the model and begin a race
            Creation.creation.model.Run();
        }
    }
}
