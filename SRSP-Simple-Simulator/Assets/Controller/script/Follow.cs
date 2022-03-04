using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace Controller
{
    public class Follow : MonoBehaviour
    {

        public Transform target;
        public Transform camera;
        public Transform music;
        public float currentX;
        public float currentY;
        public float range = 100;

        private void Start()
        {
            currentX = camera.localPosition.x;
            currentY = camera.localPosition.y;
        }
        void Update()
        {
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

            music.localPosition = new Vector3(target.localPosition.x, target.localPosition.y, music.localPosition.z);
        }

        
    }
}
