using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Struct that represents a day in the game.
    /// </summary>
    public class Day
    {
        public Day()
        {
            Day.Number++;
        }

        /// <summary>
        /// Number of this day.
        /// </summary>
        static public int Number { get; set; }

        /// <summary>
        /// If the player already clean this day.
        /// </summary>
        public bool Clean { get; set; }

        /// <summary>
        /// If the player already cook this day.
        /// </summary>
        public bool Cook { get; set; }

        /// <summary>
        /// If the player already study this day.
        /// </summary>
        public bool Study { get; set; }

        /// <summary>
        /// If the player already give a interview this day.
        /// </summary>
        public bool Interview { get; set; }

        /// <summary>
        /// If the player already protest this day.
        /// </summary>
        public bool Protest { get; set; }

        /// <summary>
        /// If this day was started
        /// </summary>
        public bool Started { get; set; }
    }
}
