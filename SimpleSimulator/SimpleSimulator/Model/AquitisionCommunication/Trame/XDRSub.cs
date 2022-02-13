using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSimulator.AquitisionCommunication.Trame
{
    public class XDRSub
    {
        public char TransducerType { get; set; }
        public float MesurementData { get; set; }
        public string UnitsMeasure { get; set; }
        public string TransducerName { get; set; }

        public override string? ToString()
        {
            return TransducerType + "," + MesurementData.ToString(CultureInfo.InvariantCulture) + "," + UnitsMeasure + "," + TransducerName;
        }
    }


}
