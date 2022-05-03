
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRace
{
    /// <summary>
    /// This class repesent a polar
    /// </summary>
    public class Polaire {

        /// <summary>
        /// Create an Polaire instance
        /// </summary>
        /// <param name="name">used to set the attribut 'name'</param>
        /// <param name="pol">used to set the attribut 'pol' </param>
        /// <param name="path">useed to set the attribut 'path'</param>
        public Polaire( string name, Dictionary<float, Dictionary<float, float>> pol, string path) {
            this.name = name;
            this.pol = pol;
            this.path = path;
        }



        private Dictionary<float, Dictionary<float,float>> pol;

        private String name;

        private String path;

        /// <summary>
        /// Search the value closest to val in the table
        /// </summary>
        /// <param name="tab">table to search in</param>
        /// <param name="val">value to approach</param>
        /// <returns>return the value closest to val in the table</returns>
        public float GetNearest(float[] tab, float val) {
            bool find = false;
            float final = 0F;
            for (int i = 0; i < tab.Length && !find; i++)
            {
                if (tab[i] > val)
                {
                    find = true;
                    if (i == 0)
                    {
                        final = tab[i];
                    }
                    else if (Math.Abs(tab[i - 1] - val) < Math.Abs(tab[i] - val))
                    {
                        final = tab[i - 1];
                    }
                    else final = tab[i];
                }
                else if (i == tab.Length - 1)
                {
                    final = tab[i];
                }
            }
            return final;
        }


        /// <summary>
        /// Search the speed induced by an wind speed and angle. Search the closest value to angle and then WindSpeed in the attribut 'polar' (Dictionary(float, Dictionary(float,float))).
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="WindSpeed"></param>
        /// <returns>return the speed induce by an wind speed and angle</returns>
        public float getSpeed(float angle, float WindSpeed) {
            //create an array containing all available angle in the polar
            float[] AngleKey = new float[this.pol.Count];
            int i = 0;
            foreach (float key in this.pol.Keys) {
                AngleKey[i] = key;
                i++;
            }
            //look for the closest available angle
            var approxAngle = GetNearest(AngleKey, angle);
            //retrieve corresponding the <speed, value dictionary>
            Dictionary<float, float> SpeedDict = new Dictionary<float, float>();
            this.pol.TryGetValue(approxAngle, out SpeedDict);

            //create an array containing available speed
            float[] speedKey = new float[SpeedDict.Count];
            i = 0;
            foreach (float key in SpeedDict.Keys)
            {
                speedKey[i] = key;
                i++;
            }
            //look for the closest available angle
            var approxSpeed = GetNearest(speedKey, WindSpeed);
            float speed = 0;
            //retreive the induced speed value
            SpeedDict.TryGetValue(approxSpeed, out speed);
            return speed;

        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return this.name;
        }

        public void setPath(string path)
        {
            this.path = path;
        }

        public string getPath()
        {
            return this.path;
        }



    }
}