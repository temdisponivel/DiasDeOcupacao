using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Script.Action;
using UnityEngine.UI;
using UnityEngine;
using Assets.Script.Ocupation;

namespace Assets.Script.Misc
{
	/// <summary>
	/// Class that represents a room in the school.
	/// </summary>
    public class Room : MonoBehaviour
    {
		/// <summary>
		/// The action that will be performed for this room.
		/// </summary>
		public Action.Action _actionPerformedInThisRoom = null;

        /// <summary>
        /// SpriteRenderer of this room.
        /// </summary>
        public SpriteRenderer _imageRoom = null;

        /// <summary>
        /// Metric that measures this room value.
        /// </summary>
        public float _roomMetric = 0f;

        public float _rateOfDecay = 0.1f;

        /// <summary>
        /// Calllback for when a day has finish and this room need to be updated.
        /// </summary>
        virtual public void DayFinished()
        {
            this._roomMetric -= this._rateOfDecay;

            if (this._roomMetric <= 0)
            {
                GameManager.Instance.GameOver(GameManager.GameOverState.RoomMetric);
            }
        }
    }
}
