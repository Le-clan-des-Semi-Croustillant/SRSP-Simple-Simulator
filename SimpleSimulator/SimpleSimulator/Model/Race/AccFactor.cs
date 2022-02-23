using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRace
{
    public class AccFactor
    {
        float compressionFactor = 1;

        public float GetAccFactorValue()
        {
            return compressionFactor;
        }

        public void SetAccFactor(float factor)
        {
            this.compressionFactor = factor;
        }
    }
}
