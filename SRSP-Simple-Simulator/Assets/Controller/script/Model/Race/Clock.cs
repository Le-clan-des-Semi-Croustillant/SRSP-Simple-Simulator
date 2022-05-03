
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PRace
{
    /// <summary>
    /// This class manage inner clock of the simulation.
    /// It contain and manage the current time of the simutation and lanch the next iteration based in the tick speed
    /// </summary>
    public class Clock {

        /// <summary>
        /// Create an instance of clock
        /// </summary>
        /// <param name="race">the affiliated race </param>
        /// <param name="accFactor">the acceleration factor of the race</param>
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

        /// <summary>
        /// Calculate the time corresponding to the next iteration and set it value to 'currentMoment' attribut
        /// </summary>
        public void IncrementTime()
        {
            if (accFactor.GetAccFactorValue() != 0)
            {
                currentMoment = currentMoment.AddMilliseconds(accFactor.GetTickValue() * accFactor.GetAccFactorValue());
            }
        }

        /// <summary>
        /// Pauses the inner clock
        /// </summary>
        public void pause()
        {
            run = false;
        }

        /// <summary>
        /// Run the inner clock
        /// </summary>
        public void Run()
        {
            IsPause = false;
            run = true;
            //run while run == true
            while (run)
            {
                Console.WriteLine("new iteration!");

                iterationOk = false;
                //lauch the iteration
                var tIteration = Task.Run(() => nextIteration());
                //lanch a timmer of the duration of a tick
                var tTick = Task.Run(() => waitTick());
                //wait for the two previous task to finish
                tIteration.Wait();
                tTick.Wait();
            }
            IsPause = true;
        }

        /// <summary>
        /// Lanch the next iteration of the race ('race' attribut)
        /// </summary>
        public void nextIteration()
        {
            try
            {
                //update the current time
                this.IncrementTime();
                // lanch the race iteration
                race.nextIteration();
                iterationOk = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Wait a tick dutation. This duration is set in the attribut 'tick' of the attribut 'accFactor'
        /// </summary>
        public void waitTick()
        {
            //wait a tick duration
            Thread.Sleep((int)accFactor.GetTickValue()); 
            Console.WriteLine("tick");
            //chack if the race iteration has finish
            if (!iterationOk)
            {
                //signal that the system can't keep up
                cantKeepUp();
            }
        }

        /// <summary>
        /// This fonction is used to signal that the system can't keep up
        /// </summary>
        public void cantKeepUp()
        {
            Console.WriteLine("Can't keep up");
        }

        public void SetCurrentMoment(DateTime currentMoment)
        {
            this.currentMoment = currentMoment;
        }

        /// <summary>
        /// Retrun if the clock is in a pause state or not
        /// </summary>
        /// <returns>true if the system is in pause else false</returns>
        public bool GetIsPause()
        {
            return this.IsPause;
        }

    }
}