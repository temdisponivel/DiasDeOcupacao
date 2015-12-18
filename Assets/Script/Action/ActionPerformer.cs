using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using Assets.Script.Misc;

namespace Assets.Script.Action
{
    /// <summary>
    /// Class that performes a action.
    /// </summary>
    public class ActionPerformer : MonoBehaviour
    {
        /// <summary>
        /// Enumerator for the possible actions.
        /// </summary>
        [Serializable]
        public enum Actions
        {
            Clean,
            Cook,
            Study,
            Interview,
            Protest,
            ResistAttack,
        }

        static public float DifficultyCoefficient { get; set; }
        static public bool InAction { get; set; }
        public float _keyVelocity = 0f;
        public float _secondsPerKey = 0f;
        public int _targetKeys = 0;
        public int _failureKeys = 0;
        public KeyCode _currentKey = KeyCode.A;
        public Text _textKeyPerform = null;
        public Actions _type = Actions.Cook;
        private float _lastKeyChange = 0f;

        virtual public void Start()
        {
            this._secondsPerKey /= ActionPerformer.DifficultyCoefficient;
            this._keyVelocity *= ActionPerformer.DifficultyCoefficient;
            this._targetKeys += (int) ActionPerformer.DifficultyCoefficient;
            this._failureKeys += (int) ActionPerformer.DifficultyCoefficient;
            this.ChangeKey();
            ActionPerformer.InAction = true;
            OptionsManager.Instance.CloseOption();
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
            GameObject.Destroy(this.gameObject);
            ActionPerformer.InAction = false;
            OptionsManager.Instance.OpenOption();
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