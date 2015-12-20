using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.Occupation
{
    /// <summary>
    /// Class that represents the status of the occupation.
    /// </summary>
    [Serializable]
    public class OccupationStatus
    {
        public enum Metrics
        {
            None,
            Clean,
            Study,
            Cook,
            PopularAdeption
        }

        public int _maxValue = 3;
        public int _minValue = 0;
        public Dictionary<Metrics, int> _status = new Dictionary<Metrics, int>();

        public OccupationStatus()
        {
            for (int i = 0; i < Enum.GetNames(typeof(Metrics)).Length; i++)
            {
                this._status.Add((Metrics) i, this._maxValue);
            }
        }

        public int this[Metrics index]
        {
            get
            {
                return this._status[index];
            }
            set
            {
                this._status[index] = Mathf.Clamp(value, this._minValue, this._maxValue);
            }
        }

        public List<Metrics> MetricsWithZero()
        {
            return this._status.Where(s => s.Value == 0).Select(v => v.Key).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>True if any of the metrics is zero</returns>
        public bool GameOver()
        {
            return this._status.Values.Any(v => v == this._minValue);
        }
    }
}