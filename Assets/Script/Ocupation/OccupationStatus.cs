using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns>True if any of the metrics is zero</returns>
        public bool GameOver()
        {
            return _cleanStatus < 0 || _studyStatus < 0 || _cookStatus < 0 || _popularAdeptance < 0;
        }
    }
}
