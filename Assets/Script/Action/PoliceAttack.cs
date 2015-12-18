using Assets.Script.Misc;
using Assets.Script.Ocupation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.Action
{
    /// <summary>
    /// Resist attack of police action
    /// </summary>
    public class PoliceAttack : ActionPerformer
    {
        public float _transitionTime = 2;
        protected override void FinishAction(bool success)
        {
            FadeManager.Instance.FadeIn();
            if (success)
            {
                this.StartCoroutine(this.WaitToSchool());
            }
            else
            {
                this.StartCoroutine(this.WaitToGameOver());
            }
        }

        /// <summary>
        /// Wait some seconds before go to game over scene.
        /// </summary>
        /// <returns></returns>
        private IEnumerator WaitToGameOver()
        {
            yield return new WaitForSeconds(this._transitionTime);
            GameManager.Instance.GameOver();
        }

        /// <summary>
        /// Waits some seconds before go to school scene.
        /// </summary>
        /// <returns></returns>
        private IEnumerator WaitToSchool()
        {
            yield return new WaitForSeconds(this._transitionTime);
            Application.LoadLevel("School");
            GameManager.Instance.FinishPoliceAttack();
        }
    }
}
