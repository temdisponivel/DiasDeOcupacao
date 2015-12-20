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

        static public float _upSubstractor = 0;
        static public bool InAction { get; set; }
        public Slider _slider = null;
        public float _downVelocity = 1;
        public float _upMultiplier = 10;
        public float _upVelocity = 1;
        public Actions _type = Actions.Cook;

        virtual public void Start()
        {
            this._upVelocity = this._downVelocity * (this._upMultiplier - ActionPerformer._upSubstractor);
            ActionPerformer.InAction = true;
            if (OptionsManager.Instance != null)
            {
                OptionsManager.Instance.CloseOption();
            }
        }

        virtual protected void FixedUpdate()
        {
            this._slider.value -= this._downVelocity * Time.deltaTime;
            this.ValidFinish();
        }

        /// <summary>
        /// Valids if this action is finish.
        /// </summary>
        private void ValidFinish()
        {
            if (this._slider.value >= this._slider.maxValue)
            {
                this.FinishAction(true);
            }
            else if (this._slider.value <= this._slider.minValue)
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
        /// OnMouseUp evento for when the player click.
        /// </summary>
        void OnMouseUp()
        {
            this._slider.value += this._upVelocity * Time.deltaTime;
            this.ValidFinish();
        }
    }
}