using System;
using System.Collections.Generic;
using UnityEngine;


namespace physicSimulator
{
    /// <summary>
    /// This class manages the calculation of the boat motions at each time interval
    /// </summary>
    public class physics_simulator {

        /// <summary>
        /// Create an physics_simulator instance
        /// </summary>
        /// <param name="env">Environment which will be used to calcul the new position</param>
        /// <param name="boat">Boat to move</param>
        /// <param name="time">object containg time compression and tick value</param>
        public physics_simulator(Environement.Environment env, PRace.Boat boat, PRace.Time time)
        {
            this.env = env;
            this.boat = boat;
            this.time = time;
        }

        private Environement.Environment env;

        private PRace.Boat boat;

        private PRace.Time time;

        private float deltat = 0;

        private float Earthradius = 6371000F;

        private float COG = 0;

        private float SOG = 0;

        private float AWS = 0;

        private float AWA = 0;

        private float STWnorm = 0; //speed

        private float STWdir = 0; //dir


        /// <summary>
        /// Set the boat to move
        /// </summary>
        /// <param name="boat"></param>
        public void SetBoat(PRace.Boat boat)
        {
            this.boat = boat;
        }

        /// <summary>
        /// Calculate the mathematical modulus of a by b
        /// </summary>
        /// <param name="a">value whose the modulo will be calculated</param>
        /// <param name="b">divider</param>
        /// <returns>double containing the modulo of a by b</returns>
        public double MathMod(double a, double b)
        {
            int integerPart = (int) (a/b);
            double mod = a - integerPart*b;
            if (a*b < 0)
            {
                mod = mod + b;
            }
            return mod;
        }

        /// <summary>
        /// Calculate a iteration of the physic simulation.
        /// First calculate the motion of the boat in the tangent plane,
        /// then project this motion on a sphere of the Earth radius divided by the time compression value.
        /// Also calcute the new COG and SOG
        /// and change the boat position to its next position
        /// </summary>
        public void Move()
        {
            //retreive environmental values
            Dictionary<Environement.Conditions, float> envState = env.getEnvState();
            float ws, wd, cs, cd;
            envState.TryGetValue(Environement.Conditions.CurrentSpeed, out cs);
            envState.TryGetValue(Environement.Conditions.CurrentDirection, out cd);
            envState.TryGetValue(Environement.Conditions.WindSpeed, out ws);
            envState.TryGetValue(Environement.Conditions.WindDirection, out wd);
            //calculate the motion in the tangente plane
            (float x,float y) step = nextStep(ws, wd, cs, cd);
            //calculate the COG and SOG of the boat
            (SOG, COG) = CalculateAngle(step);
            if (step.x != 0 || step.y != 0)
            {
                //project the motion on the sphere
                (double teta, double phi, float cap) modif = projectionOnSphere(step);
                //modify the boat heading and set the new position
                boat.setCap(modif.cap);
                boat.GetPosition().Update(modif.phi / (Mathf.PI*2) * 360, modif.teta/ Mathf.PI * 180);
            }
        }

        /// <summary>
        /// Calculate the norm of the input vector and
        /// calculate the angle relative to [1,0] vector
        /// </summary>
        /// <param name="vect">input vector whose norm and angle need to be calculated</param>
        /// <returns>a tuple of two float containing the norm and angle of the input vector</returns>
        private (float norm, float angle) CalculateAngle((float x, float y) vect)
        {
            float angle;
            float norm = CalculateNorm(vect.x, vect.y);
            if (norm == 0)
            {
                return (0, 0);
            }
            float costw = dot(1, 0, vect.x, vect.y) / norm;

            if (vect.y >= 0)
            {
                angle = Mathf.Acos(costw);
            }
            else
            {
                angle = (-Mathf.Acos(costw) + 2 * Mathf.PI) % (2 * Mathf.PI);
            }

            return (norm , angle);
        }

        /// <summary>
        /// Calculate the next move on the tangent plane of the boat attribut based on environment state and tick speed
        /// </summary>
        /// <remarks>in this method the x axis is from south to north and y axis form east to west</remarks>
        /// <param name="ws">Wind Speed</param>
        /// <param name="wd">Wind direction</param>
        /// <param name="cs">Currrent Speed</param>
        /// <param name="cd">Current direction</param>
        /// <returns>a tuple of two float representing: the move following the x and y axes</returns>
        private (float x, float y) nextStep(float ws, float wd, float cs, float cd)
        {
            float dirtw, windAngle;
            (float x, float y) nextStep, currentVector, windVector;
            //calculate the current vector
            if (cs != 0)
            {
                currentVector = (Mathf.Cos(cd / 360 * 2 * Mathf.PI) * cs, Mathf.Sin(cd / 360 * 2 * Mathf.PI) * cs);
            }
            else
            {
                currentVector = (0, 0);
            }
            //calculate the wind vector
            if (ws != 0)
            {
                windVector = (Mathf.Cos(wd / 360 * 2 * Mathf.PI) * ws, Mathf.Sin(wd / 360 * 2 * Mathf.PI) * ws);
            }
            else
            {

                windVector = (0, 0);
            }

            //calculate true wind (wind on current)
            (float x, float y) trueWindVector = (windVector.x - currentVector.x, windVector.y - currentVector.y);
            float twNorm = CalculateNorm(trueWindVector.x, trueWindVector.y);

            //case where the wind as no impact on the boat motion
            if (twNorm == 0 || boat.GetCurrentPolaire() == null)
            {
                nextStep = (currentVector.x, currentVector.y);

            }
            else
            {
                //calculate true wind angle to [1,0]
                float costw = dot(1, 0, trueWindVector.x, trueWindVector.y) / twNorm;
                float sintw = CrossProductNorm(1, 0, trueWindVector.x, trueWindVector.y) / twNorm;

                dirtw = trueWindVector.y / Mathf.Abs(trueWindVector.y) * Mathf.Acos(costw);
                dirtw = dirtw / (2 * Mathf.PI) * 360;

                //calculate true wind angle
                windAngle = (float)MathMod((boat.getCap() - dirtw), 360);
                if (windAngle == 0 || windAngle == 360)
                {
                    windAngle = 180;
                }
                else if (windAngle == 180)
                {
                    windAngle = 0;
                }
                else
                {
                    windAngle = windAngle - 180;
                    windAngle = (Mathf.Abs(windAngle) + 180) % 180;
                }
                //create a heading vector
                float capInRad = boat.getCap()/360*2*Mathf.PI;
                (float x, float y) capVector = (Mathf.Cos(capInRad), Mathf.Sin(capInRad)); 

                //calcutate the contribution of the wind to the motion
                float windForce = boat.GetCurrentPolaire().getSpeed(windAngle, twNorm * 1.94384F)/ 1.94384F;
                //calculatute the motion of the boat in 1 second
                nextStep = (currentVector.x + windForce * capVector.x , currentVector.y + windForce * capVector.y);

            }

            //motion par rapport à vent
            float MWVangle;
            (float x, float y) MWVVector = (windVector.x - nextStep.x, windVector.y - nextStep.y);
            (this.AWS, MWVangle) = CalculateAngle(MWVVector);
            this.AWA = (MWVangle - boat.getCapRad()+180)%360;


            //motion par rapport à l'eau
            float VHWangle;
            (float x, float y) VHWVector = (currentVector.x - nextStep.x, currentVector.y - nextStep.y);
            (this.STWnorm, VHWangle) = CalculateAngle(VHWVector);
            this.STWdir = VHWangle - boat.getCapRad();

            //motion during a tick
            nextStep = (nextStep.x * time.GetTickValue()/1000, nextStep.y * time.GetTickValue()/1000);
            return nextStep;
        }

        /// <summary>
        /// Calculate the projection of a motion from the tangent plan to the sphere
        /// </summary>
        /// <param name="step"></param>
        /// <returns>tuple of three double reprenting: sphecal coordinates and heading of the boat</returns>
        private (double teta, double phi, float cap) projectionOnSphere((float x, float y) step)
        {
            double dphi, phi, dteta, teta;
            float cap = boat.getCap();

            //check for null acceleration factor
            if (time.GetAccFactorValue() == 0)
            {
                teta = 0;
                phi = 0;
            }
            else
            {
                float radius = Earthradius / time.GetAccFactorValue();
                float stepNorm = CalculateNorm(step.x, step.y);
                // Calcultate and project the motion following latitude 
                dteta = dot(1, 0, step.x, step.y) / radius;
                double radiusTeta = (radius * Math.Sin(boat.GetPosition().GetLatitudeAngle()));

                // pole case
                if (radiusTeta == 0 || step.y == 0)
                {
                    dphi = 0;
                }
                else
                {
                    // Calcultate and project the motion following longitude 
                    dphi = step.y / Mathf.Abs(step.y) * CrossProductNorm(1, 0, step.x, step.y) / radiusTeta;
                }
                /// new latitude
                teta = boat.GetPosition().GetLatitudeAngle() + dteta;


                // case when a pole is cross
                if (teta != MathMod(teta, Mathf.PI))
                {
                    teta = MathMod(-teta, Mathf.PI);
                    cap = cap + 180;
                    // new longitude
                    phi = MathMod((boat.GetPosition().GetLongitudeAngle() + Mathf.PI - dphi), 2 * Mathf.PI);
                }
                else
                {
                    // new longitude
                    phi = MathMod((boat.GetPosition().GetLongitudeAngle() + dphi), 2 * Mathf.PI);
                }
            }
            return (teta, phi, cap);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xa"></param>
        /// <param name="ya"></param>
        /// <param name="xb"></param>
        /// <param name="yb"></param>
        /// <returns></returns>
        private float dot(float xa, float ya, float xb, float yb)
        {
            return xa * xb + ya * yb;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xa"></param>
        /// <param name="ya"></param>
        /// <param name="xb"></param>
        /// <param name="yb"></param>
        /// <returns></returns>
        private float CrossProductNorm(float xa, float ya, float xb, float yb)
        {
            float z = ya * xb - yb * xa;
            return (Mathf.Abs(z));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private float CalculateNorm(float x, float y)
        {
            return Mathf.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float GetCOG()
        {
            return COG;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float GetCOGDegre()
        {
            return COG * 180 / (float)Math.PI;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float GetSOG()
        {
            return SOG * 1.94384F;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float GetSTW()
        {
            return STWnorm * 1.94384F;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float GetSTWdirDegre()
        {
            return ((STWdir + (float)Math.PI) % (2* (float)Math.PI))* 180 / (float)Math.PI;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float GetAWS()
        {
            return AWS * 1.94384F;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float GetAWADegre()
        {
            return ((AWA + (float)Math.PI) % (2 * (float)Math.PI)) * 180 / (float)Math.PI;
        }
    }
}