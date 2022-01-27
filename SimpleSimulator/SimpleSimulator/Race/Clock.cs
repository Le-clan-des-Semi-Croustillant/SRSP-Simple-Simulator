
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Race{
    public class Clock {

        public Clock() {
        }

        private DateTime deltaT;

        private DateTime moment;

        public DateTime GetCurrentMoment()
        {
            return moment;
        }
        public void nextIteration() {
            // TODO implement here
        }

    }
}