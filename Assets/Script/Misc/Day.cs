using Assets.Script.Occupation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Struct that represents a day in the game.
    /// </summary>
    public class Day
    {
        /// <summary>
        /// Number of this day.
        /// </summary>
        static public int Number { get; set; }

        private List<bool?> _actions = new List<bool?>();//[Enum.GetNames(typeof(Action.ActionPerformer.Actions)).Length];

        public Day()
        {
            Day.Number++;
            for (int i = 0; i < Enum.GetNames(typeof(Action.ActionPerformer.Actions)).Length; i++)
            {
                this._actions.Add(new bool?());
            }
        }

        /// <summary>
        /// Get or set if some given action was already perfom today.
        /// </summary>
        /// <param name="type">Type of the action</param>
        /// <returns>True if was performed. False otherwise</returns>
        public bool this[Action.ActionPerformer.Actions type]
        {
            get
            {
                return (this._actions[(int)type].HasValue ? this._actions[(int)type].Value : false);
            }
            set
            {
                this._actions[(int)type] = value;
                this.CheckFinish();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">Type of the action</param>
        /// <returns>True if perform the specific action</returns>
        public bool HasPerformed(Action.ActionPerformer.Actions type)
        {
            return this._actions[(int) type].HasValue;
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
            if (this._actions.All(b => b.HasValue))
            {
                GameManager.Instance.FinishDay();
            }
        }
    }
}
