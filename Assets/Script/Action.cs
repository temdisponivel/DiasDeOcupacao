using UnityEngine;
using System.Collections;
using System;

namespace Assets.Script
{
    /// <summary>
    /// Class that represents a action in game.
    /// </summary>
    public class Action : MonoBehaviour
    {
        /// <summary>
        /// Enumerator for better management of the actions.
        /// </summary>
        public enum ActionTypes
        {
            Clean,
            Cook,
            Read,
            Protest,
            Interview
        }

        public string _name = "";
        public ActionTypes _type;
        public Person.PersonAbilities _abilityRequered;
        private Action<float> _callback = null;

        void Start()
        {

        }

        void Update()
        {

        }

        /// <summary>
        /// Add a callback funcion to be called when this Action finishs.
        /// </summary>
        /// <param name="callback">Callback function that will receive as parameter the force created by this action</param>
        public void SetCallback(Action<float> callback)
        {
            this._callback = callback;
        }
    }
}