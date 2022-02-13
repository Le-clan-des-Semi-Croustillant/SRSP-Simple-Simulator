
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace physicSimulator{
    public class physics_simulator {

        public physics_simulator() {
        }
        
        private Environement.Environment env;

        private PRace.Boat boat;

        private float accFactor;

        private float deltat = 1;

        private float radius = 6371000F;


        public void init(Environement.Environment env, PRace.Boat boat)
        {
            this.env = env;
            this.boat = boat;
        }

        public void ComputePhysique() {
            // TODO implement here
        }

        public void SetAccelerationFactor(float acc)
        {
            this.accFactor = acc;
        }

        public void SetBoat(PRace.Boat boat)
        {
            this.boat = boat;
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
            if (step.x != 0 || step.y != 0)
            {
                (float teta, float phi, float cap) modif = projectionOnSphere(step);
                boat.setCap(modif.cap);
                boat.GetPosition().Update(modif.phi / (MathF.PI*2) * 360, modif.teta/ MathF.PI * 180);
            }
        }

        private (float x, float y) nextStep(float ws, float wd, float cs, float cd)
        {
            float dirtw, windAngle;
            (float x, float y) nextStep, currentVector, windVector;
            if (cs != 0)
            {
                currentVector = (MathF.Cos(cd / 360 * 2 * MathF.PI) * cs, MathF.Sin(cd / 360 * 2 * MathF.PI) * cs);
            }
            else
            {
                currentVector = (0, 0);
            }
            if (ws != 0)
            {
                windVector = (MathF.Cos(wd / 360 * 2 * MathF.PI) * ws, MathF.Sin(wd / 360 * 2 * MathF.PI) * ws);
            }
            else
            {

                windVector = (0, 0);
            }

            (float x, float y) trueWindVector = (windVector.x - currentVector.x, windVector.y - currentVector.y);
            float twNorm = norm(trueWindVector.x, trueWindVector.y);

            if (twNorm == 0)
            {
                nextStep = (currentVector.x, currentVector.y);

            }
            else
            {
                
                float costw = dot(1, 0, trueWindVector.x, trueWindVector.y) / twNorm;
                float sintw = CrossProductNorm(1, 0, trueWindVector.x, trueWindVector.y) / twNorm;

                if (sintw >= 0)
                {
                    dirtw = MathF.Acosh(costw);
                }
                else
                {
                    dirtw = MathF.Acosh(costw) + MathF.PI;
                }
                dirtw = dirtw / (2 * MathF.PI) * 360;

                windAngle = (boat.getCap() - dirtw) % 360;
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
                    windAngle = (windAngle * (windAngle - 180 / MathF.Abs(windAngle - 180))) % 180;
                }
                float capInRad = boat.getCap()/360*2*MathF.PI;
                (float x, float y) capVector = (MathF.Cos(capInRad), MathF.Sin(capInRad)); 

                float windForce = boat.GetCurrentPolaire().getSpeed(windAngle, twNorm);
                nextStep = (currentVector.x + windForce * capVector.x , currentVector.y + windForce * capVector.y);
            }
            return nextStep;
        }

        private (float teta, float phi, float cap) projectionOnSphere((float x, float y) step)
        {
            float dphi, phi;
            float stepNorm = norm(step.x, step.y);
            float sinstep = CrossProductNorm(1, 0, step.x, step.y) / stepNorm;
            float dteta = dot(1, 0, step.x, step.y) / radius;
            float radiusTeta = (radius * MathF.Sin(boat.GetPosition().GetLatitudeAngle()));
            if (radiusTeta == 0)
            {
                dphi = 0;
            }
            else {
                dphi = CrossProductNorm(1, 0, step.x, step.y) / radiusTeta;
            }
            float cap = boat.getCap();
            float teta = boat.GetPosition().GetLatitudeAngle() + dteta;
            if (teta != teta % MathF.PI)
            {
                teta = -(teta % MathF.PI) + MathF.PI;
                cap = cap + 180;
                phi = ( boat.GetPosition().GetLongitudeAngle() + MathF.PI - dphi ) % MathF.PI;
            }
            else
            {
                phi = boat.GetPosition().GetLongitudeAngle() + dphi;
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
            return (MathF.Abs(z));
        }

        private float norm(float x, float y)
        {
            return MathF.Sqrt(x * x + y * y);
        }
    }
}