using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

namespace Assets.Script.Action.ActionPerformer
{
    /// <summary>
    /// Class that performes a action.
    /// </summary>
    public class ActionPerformer : MonoBehaviour
    {
        public System.Action _callback = null;
        public float _secondsPerKey = 0f;
        public int _keyQuantity = 0;
        public KeyCode _currentKey = KeyCode.A;
        public Text _textKeyPerform = null;
        private float _lastKeyChange = 0f;
        private int _keysChanged = 0;

        void Update()
        {
            if (Time.time - this._lastKeyChange >= this._lastKeyChange - _secondsPerKey)
            {
                this.ChangeKey();
            }

            if (Input.GetKeyDown(_currentKey))
            {
                this.ChangeKey();
            }

            if (this._keysChanged >= this._keyQuantity)
            {
                GameObject.Destroy(this.gameObject);
            }
        }

        /// <summary>
        /// Add a callback funcion to be called when this Action finishs.
        /// </summary>
        /// <param name="callback">Callback function that will receive as parameter the force created by this action</param>
        public void SetCallback(System.Action callback)
        {
            this._callback = callback;
        }

        /// <summary>
        /// Changes the current key to be pressed.
        /// </summary>
        public void ChangeKey()
        {
            int keyIndex = UnityEngine.Random.Range(97, 123); //Min e Max of the alphabetics key code
            this._currentKey = (KeyCode) keyIndex;
            this._textKeyPerform.text = this._currentKey.ToString();
        }
    }
}