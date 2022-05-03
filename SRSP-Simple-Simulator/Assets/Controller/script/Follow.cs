using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace Unityscript
{
    /// <summary>
    /// Manage the camera/music to follow the boat within a range
    /// </summary>
    public class Follow : MonoBehaviour
    {

        public Transform target;
        public Transform camera;
        public Transform music;
        public float currentX;
        public float currentY;
        //range can be change
        public float range = 100;

        private void Start()
        {
            currentX = camera.localPosition.x;
            currentY = camera.localPosition.y;
        }
        void Update()
        {
            //the camera get track on the boat by a range
            //if the boat get out on this range the camera will reset its positions to the boat one
            if (target.position.y > currentY + range || target.position.y < currentY - range)
            {
                camera.localPosition = new Vector3(target.localPosition.x, target.localPosition.y, camera.localPosition.z);
                currentY = camera.localPosition.y;
            }
            if (target.position.x > currentX + range || target.position.x < currentX - range)
            {
                camera.localPosition = new Vector3(target.localPosition.x, target.localPosition.y, camera.localPosition.z);
                currentX = camera.localPosition.x;
            }
            // the music constantly follows the boat
            music.localPosition = new Vector3(target.localPosition.x, target.localPosition.y, music.localPosition.z);
        }

        
    }
}
