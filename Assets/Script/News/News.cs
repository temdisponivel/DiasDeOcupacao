using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.News
{
    /// <summary>
    /// Class that represents a new in the game.
    /// </summary>
    public class News : MonoBehaviour
    {
        /// <summary>
        /// Enumerator for better handling news type.
        /// </summary>
        public enum NewsType
        {
            ProOcupation,
            CounterOcupation,
            Slanderous,
            Truthful,
            Neutral
        }
    }
}
