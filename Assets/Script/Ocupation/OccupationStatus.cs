using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.Ocupation
{
    /// <summary>
    /// Class that represents the status of the occupation.
    /// </summary>
    [Serializable]
    public class OccupationStatus
    {
        public int _maxStatus = 3;
        public int _cleanStatus = 3;
        public int _studyStatus = 3;
        public int _cookStatus = 3;
        public int _popularAdeptance = 0;
    }
}
