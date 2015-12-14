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
        public int _points = 3;
        public float _secondsPerKey = 0f;
        public int _targetKeys = 0;
        public int _failureKeys = 0;
        public KeyCode _currentKey = KeyCode.A;
        public Text _textKeyPerform = null;
        private float _lastKeyChange = 0f;

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
            else if (Input.anyKeyDown && !Input.GetKeyDown(_currentKey))
            {
                this._failureKeys--;
                this.ChangeKey();
            }
            else if (Input.GetKeyDown(_currentKey))
            {
                this._targetKeys--;
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
            else if (this._failureKeys == 0)
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
                Debug.Log(this._points);
                this.UpdateStatusMetric(this._points);
            }
            else
            {
                this.UpdateStatusMetric(-(this._points));
            }
            GameObject.Destroy(this.gameObject);
        }

        /// <summary>
        /// Method that perform the update of the ocupation force by a given pontuation.
        /// </summary>
        /// <param name="points">Points to add.</param>
        protected void UpdateStatusMetric(int points)
        {
            Ocupation.Ocupation.Instance._ocupationForce += points;
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
        }
    }
}