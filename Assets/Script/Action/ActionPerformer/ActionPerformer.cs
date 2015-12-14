using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using Assets.Script.Misc;

namespace Assets.Script.Action.ActionPerformer
{
    /// <summary>
    /// Class that performes a action.
    /// </summary>
    public class ActionPerformer : MonoBehaviour
    {
        public System.Action _callback = null;
        public int _points = 3;
        public float _secondsPerKey = 0f;
        public int _targetKeys = 0;
        public int _failureKeys = 0;
        public KeyCode _currentKey = KeyCode.A;
        public Text _textKeyPerform = null;
        private float _lastKeyChange = 0f;
        private int _keysChanged = 0;

        public void Start()
        {
            this.ChangeKey();
        }

        virtual protected void Update()
        {
            if (Time.time - this._lastKeyChange >= this._secondsPerKey)
            {
                this._failureKeys--;
                this.ChangeKey();
            }

            if (Input.GetKeyDown(_currentKey))
            {
                this._targetKeys++;
                this.ChangeKey();
            }

            if (Input.anyKey && !Input.GetKeyDown(_currentKey))
            {
                this._failureKeys--;
                this.ChangeKey();
            }

            this.ValidFinish();
        }

        /// <summary>
        /// Valids if this action is finish.
        /// </summary>
        private void ValidFinish()
        {
            if (this._targetKeys == 0)
            {
                this.FinishAction(true);
            }

            if (this._failureKeys == 0)
            {
                this.FinishAction(false);
            }
        }

        /// <summary>
        /// Method called when this action is finish.
        /// </summary>
        virtual protected void FinishAction(bool success)
        {
            if (success)
            {
                this.UpdateStatusMetric(this._points);
            }
            else
            {
                this.UpdateStatusMetric(-this._points);
            }
            this._callback();
            GameObject.Destroy(this.gameObject);
        }

        /// <summary>
        /// Method that perform the update of the ocupation force by a given pontuation.
        /// </summary>
        /// <param name="points">Points to add.</param>
        protected void UpdateStatusMetric(int points)
        {
            Ocupation.Ocupation.Instance._ocupationForce += this._points;
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

            this._lastKeyChange = Time.time;
            this._keysChanged++;
        }
    }
}