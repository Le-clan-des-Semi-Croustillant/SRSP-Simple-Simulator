
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRace
{
    public class Polaire {

        public Polaire( string name, Dictionary<float, Dictionary<float, float>> pol) {
            this.name = name;
            this.pol = pol;
        }



        private Dictionary<float, Dictionary<float,float>> pol;

        private String name;


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
        /// @param int WindSpeed 
        /// @param int angle
        /// </summary>
        public float getSpeed(float angle, float WindSpeed) {
            float[] AngleKey = new float[this.pol.Count];
            int i = 0;
            foreach (float key in this.pol.Keys) {
                AngleKey[i] = key;
                i++;
            }
            var approxAngle = GetNearest(AngleKey, angle);
            Dictionary<float, float> SpeedDict = new Dictionary<float, float>();
            this.pol.TryGetValue(approxAngle, out SpeedDict);

            float[] speedKey = new float[SpeedDict.Count];
            i = 0;
            foreach (float key in SpeedDict.Keys)
            {
                speedKey[i] = key;
                i++;
            }
            var approxSpeed = GetNearest(speedKey, WindSpeed);
            float speed = 0;
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



    }
}