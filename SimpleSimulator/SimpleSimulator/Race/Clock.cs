
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race{
    public class Clock {

        public Clock(Race race) {
            this.race = race;
        }

        private DateTime currentMoment;

        private int tickSpeed = 200;

        private bool run = true;

        private bool IsPause = false;

        private bool iterationOk = false;

        private Race race;

        public DateTime GetCurrentMoment()
        {
            return currentMoment;
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
            iterationOk = true;
            race.nextIteration();
        }

        public void waitTick()
        {
            Thread.Sleep(tickSpeed); 
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