using System;
using System.Collections.Generic;
using UnityEngine;


namespace physicSimulator
{
    public class physics_simulator {

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

        private float SWTnorm = 0;

        private float SWTdir = 0;

        private float VHWnorm = 0;

        private float VHWdir = 0;


        public void SetBoat(PRace.Boat boat)
        {
            this.boat = boat;
        }

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

        public void Move()
        {
            Dictionary<Environement.Conditions, float> envState = env.getEnvState();
            float ws, wd, cs, cd;
            envState.TryGetValue(Environement.Conditions.CurrentSpeed, out cs);
            envState.TryGetValue(Environement.Conditions.CurrentDirection, out cd);
            envState.TryGetValue(Environement.Conditions.WindSpeed, out ws);
            envState.TryGetValue(Environement.Conditions.WindDirection, out wd);
            (float x,float y) step = nextStep(ws, wd, cs, cd);
            (SOG, COG) = CalculateAngle(step);
            if (step.x != 0 || step.y != 0)
            {
                (double teta, double phi, float cap) modif = projectionOnSphere(step);
                boat.setCap(modif.cap);
                boat.GetPosition().Update(modif.phi / (Mathf.PI*2) * 360, modif.teta/ Mathf.PI * 180);
            }
        }

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

            return (norm * time.GetAccFactorValue(), angle);
        }

        private (float x, float y) nextStep(float ws, float wd, float cs, float cd)
        {
            float dirtw, windAngle;
            (float x, float y) nextStep, currentVector, windVector;
            if (cs != 0)
            {
                currentVector = (Mathf.Cos(cd / 360 * 2 * Mathf.PI) * cs, Mathf.Sin(cd / 360 * 2 * Mathf.PI) * cs);
            }
            else
            {
                currentVector = (0, 0);
            }
            if (ws != 0)
            {
                windVector = (Mathf.Cos(wd / 360 * 2 * Mathf.PI) * ws, Mathf.Sin(wd / 360 * 2 * Mathf.PI) * ws);
            }
            else
            {

                windVector = (0, 0);
            }

            (float x, float y) trueWindVector = (windVector.x - currentVector.x, windVector.y - currentVector.y);
            float twNorm = CalculateNorm(trueWindVector.x, trueWindVector.y);

            if (twNorm == 0 || boat.GetCurrentPolaire() == null)
            {
                nextStep = (currentVector.x, currentVector.y);

            }
            else
            {
                
                float costw = dot(1, 0, trueWindVector.x, trueWindVector.y) / twNorm;
                float sintw = CrossProductNorm(1, 0, trueWindVector.x, trueWindVector.y) / twNorm;

                dirtw = trueWindVector.y / Mathf.Abs(trueWindVector.y) * Mathf.Acos(costw);
                dirtw = dirtw / (2 * Mathf.PI) * 360;

                windAngle = (float)MathMod((boat.getCap() - dirtw), 360);
                if (windAngle == 0)
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
                float capInRad = boat.getCap()/360*2*Mathf.PI;
                (float x, float y) capVector = (Mathf.Cos(capInRad), Mathf.Sin(capInRad)); 

                float windForce = boat.GetCurrentPolaire().getSpeed(windAngle, twNorm * 1.94384F);
                this.SWTnorm = windForce;
                nextStep = (currentVector.x + windForce * capVector.x , currentVector.y + windForce * capVector.y);
                float currentAngle = CalculateAngle(currentVector).angle;
                float stepAngle = CalculateAngle(nextStep).angle;
                this.SWTdir = stepAngle - currentAngle;

                (float x, float y) VHWVector = (nextStep.x = windVector.x, nextStep.y - windVector.y);
                (float VHWVectorNorm, float VHWVectorAngle) = CalculateAngle(VHWVector);
                this.VHWnorm = VHWVectorNorm;
                this.VHWdir = VHWVectorAngle - this.boat.getCap();
            }
            nextStep = (nextStep.x * time.GetTickValue()/1000, nextStep.y * time.GetTickValue()/1000);
            return nextStep;
        }

        private (double teta, double phi, float cap) projectionOnSphere((float x, float y) step)
        {
            double dphi, phi, dteta, teta;
            float cap = boat.getCap();
            if (time.GetAccFactorValue() == 0)
            {
                teta = 0;
                phi = 0;
            }
            else
            {
                float radius = Earthradius / time.GetAccFactorValue();
                float stepNorm = CalculateNorm(step.x, step.y);
                dteta = dot(1, 0, step.x, step.y) / radius;
                double radiusTeta = (radius * Math.Sin(boat.GetPosition().GetLatitudeAngle()));
                if (radiusTeta == 0 || step.y == 0)
                {
                    dphi = 0;
                }
                else
                {
                    dphi = step.y / Mathf.Abs(step.y) * CrossProductNorm(1, 0, step.x, step.y) / radiusTeta;
                }
                teta = boat.GetPosition().GetLatitudeAngle() + dteta;
                if (teta != MathMod(teta, Mathf.PI))
                {
                    teta = MathMod(-teta, Mathf.PI);
                    cap = cap + 180;
                    phi = MathMod((boat.GetPosition().GetLongitudeAngle() + Mathf.PI - dphi), 2 * Mathf.PI);
                }
                else
                {
                    phi = MathMod((boat.GetPosition().GetLongitudeAngle() + dphi), 2 * Mathf.PI);
                }
            }
            return (teta, phi, cap);
        }

        private float dot(float xa, float ya, float xb, float yb)
        {
            return xa * xb + ya * yb;
        }

        private float CrossProductNorm(float xa, float ya, float xb, float yb)
        {
            float z = ya * xb - yb * xa;
            return (Mathf.Abs(z));
        }

        private float CalculateNorm(float x, float y)
        {
            return Mathf.Sqrt(x * x + y * y);
        }

        public float GetCOG()
        {
            return COG;
        }

        public float GetSOG()
        {
            return SOG;
        }

        public float GetSWT()
        {
            return SWTnorm;
        }
        public float GetSWTdir()
        {
            return SWTdir;
        }
        public float GetVHW()
        {
            return VHWnorm;
        }
        public float GetVHWdir()
        {
            return VHWdir;
        }
    }
}