using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Enumerate all information about the boat that should be transmitted ton the interface
    /// </summary>
    public enum BoatInfo
    {
        Longitude,
        Latitude,
        Cap,
        COG,
        SOG,
        STW,
        AWS,
        AWA,
    }
}
