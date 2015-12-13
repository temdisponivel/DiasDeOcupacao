using UnityEngine;
using System.Collections;
using System;
using Assets.Script.Ocupation;
using Assets.Script.Misc;
using Assets.Script.Action.ActionPerformer;

namespace Assets.Script.Action
{
    /// <summary>
    /// Class that represents a action in game.
    /// </summary>
    public class Action : MonoBehaviour
    {
        public string _name = "";
        private System.Action _callback = null;
        public GameObject _performer = null;

        void Start()
        {
            ActionPerformer.ActionPerformer performer = (GameObject.Instantiate(this._performer) as GameObject).GetComponent<ActionPerformer.ActionPerformer>();
            performer.SetCallback(this.ActionFinished);
        }

        /// <summary>
        /// Add a callback funcion to be called when this Action finishs.
        /// </summary>
        public void SetCallback(System.Action callback)
        {
            this._callback = callback;
        }

        /// <summary>
        /// Callback for the ActionPerformer.
        /// </summary>
        public void ActionFinished()
        {
            this._callback();
        }
    }
}