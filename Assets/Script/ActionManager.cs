using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Script
{
    /// <summary>
    /// Class that manage all types of actions in game.
    /// </summary>
    public class ActionManager : MonoBehaviour
    {
        public ActionDictionary[] _actionType = null;
        private Dictionary<Action.ActionTypes, Action> _actions = null;
        public bool OnAction { get; set; }
        public Action CurrentAction { get; set; }

        void Start()
        {
            this._actions = new Dictionary<Action.ActionTypes, Action>();
            foreach (var action in this._actionType)
            {
                this._actions.Add(action._type, action._action);
            }
        }

        void Update()
        {

        }

        public void StartAction(Action.ActionTypes actionType)
        {
            GameObject.Instantiate(this._actions[actionType]).SetCallback(this.FinishAction);
        }

        public void FinishAction(float forceCreate)
        {
        }
    }
}