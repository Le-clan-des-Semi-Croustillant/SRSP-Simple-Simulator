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
        public char TransducerType { get; set; } = 'A';
        public float MesurementData { get; set; } = 0f;
        public string UnitsMeasure { get; set; } = "D";
        public string TransducerName { get; set; } = "ROLL";

        public override string? ToString()
        {
            return TransducerType + "," + MesurementData.ToString(CultureInfo.InvariantCulture) + "," + UnitsMeasure + "," + TransducerName;
        }
    }


}
