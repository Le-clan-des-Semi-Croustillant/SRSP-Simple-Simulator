
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Race{
    public class Polaire {

        public Polaire( Dictionary<float, Dictionary<float, float>> pol) {
            this.pol = pol;
        }



        public Dictionary<float, Dictionary<float,float>> pol;


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
        public float getSpeed(float WindSpeed, float angle) {
            float[] WindSpeedKey = new float[this.pol.Count];
            int i = 0;
            foreach (float key in this.pol.Keys) {
                WindSpeedKey[i] = key;
                i++;
            }
            var approxWS = GetNearest(WindSpeedKey, WindSpeed);
            Dictionary<float, float> angleDict = new Dictionary<float, float>();
            this.pol.TryGetValue(approxWS, out angleDict);

            float[] angleKey = new float[angleDict.Count];
            i = 0;
            foreach (float key in angleDict.Keys)
            {
                angleKey[i] = key;
                i++;
            }
            var approxAngle = GetNearest(angleKey, angle);
            float speed = 0;
            angleDict.TryGetValue(approxAngle, out speed);
            return speed;

        }




    }
}