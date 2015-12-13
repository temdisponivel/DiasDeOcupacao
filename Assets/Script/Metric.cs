using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script
{
    public class Metric
    {
        protected int _value = 0;

        /// <summary>
        /// The value of this metric.
        /// </summary>
        public int Value { get { return _value; } set { _value = value; } }
    }
}
