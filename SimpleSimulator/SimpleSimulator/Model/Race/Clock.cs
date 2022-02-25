
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRace
{
    public class Clock {

        public Clock(Race race, Time accFactor) {
            this.race = race;
            this.accFactor = accFactor;
        }

        private DateTime currentMoment;

        private Time accFactor;

        private bool run = false;

        private bool IsPause = true;

        private bool iterationOk = false;

        private Race race;

        public DateTime GetCurrentMoment()
        {
            return currentMoment;
        }

        public void IncrementTime()
        {
            currentMoment = currentMoment.AddMilliseconds(accFactor.GetTickValue());
        }

        public void pause()
        {
            run = false;
        }

        public void Run()
        {
            IsPause = false;
            run = true;
            while (run)
            {
                Console.WriteLine("new iteration!");

                iterationOk = false;
                var tIteration = Task.Run(() => nextIteration());
                var tTick = Task.Run(() => waitTick());
                tIteration.Wait();
                tTick.Wait();
            }
            IsPause = true;
        }

        public void nextIteration()
        {
            this.IncrementTime();
            race.nextIteration();
            iterationOk = true;
        }

        public void waitTick()
        {
            Thread.Sleep((int)accFactor.GetTickValue()); 
            Console.WriteLine("tick");
            if (!iterationOk)
            {
                cantKeepUp();
            }
        }

        public void cantKeepUp()
        {
            Console.WriteLine("Can't keep up");
        }

        public void SetCurrentMoment(DateTime currentMoment)
        {
            this.currentMoment = currentMoment;
        }

        public bool GetIsPause()
        {
            return this.IsPause;
        }

    }
}