using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Script.Misc;

namespace Assets.Script.Action
{
    /// <summary>
    /// Class that manage all types of actions in game.
    /// </summary>
    public class ActionManager : MonoBehaviour
    {
        public bool OnAction { get; set; }
        public Action CurrentAction { get; set; }

        void Update()
        {

        }

        public void StartAction(Action action)
        {
            GameObject.Instantiate(action).SetCallback(this.FinishAction);
        }

        public void FinishAction()
        {

        }
    }
}