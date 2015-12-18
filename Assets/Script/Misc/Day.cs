using Assets.Script.Ocupation;
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

        private bool[] _actions = new bool[Enum.GetNames(typeof(Action.ActionPerformer.Actions)).Length];

        /// <summary>
        /// Get or set if some given action was already perfom today.
        /// </summary>
        /// <param name="type">Type of the action</param>
        /// <returns>True if was performed. False otherwise</returns>
        public bool this[Action.ActionPerformer.Actions type]
        {
            get
            {
                return this._actions[(int) type];
            }
            set
            {
                this._actions[(int) type] = value;
                this.CheckFinish();
            }
        }

        /// <summary>
        /// If this day was started
        /// </summary>
        public bool Started { get; set; }

        /// <summary>
        /// Method that checks if all possible actions of the day were done.
        /// </summary>
        public void CheckFinish()
        {
            if (this[Action.ActionPerformer.Actions.Clean] && this[Action.ActionPerformer.Actions.Cook] && this[Action.ActionPerformer.Actions.Study]
                && this[Action.ActionPerformer.Actions.Interview] && this[Action.ActionPerformer.Actions.Protest])
            {
                GameManager.Instance.FinishDay();
            }
        }
    }
}
