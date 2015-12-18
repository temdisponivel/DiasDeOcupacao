using Assets.Script.Ocupation;
using System;
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
        public GameObject _policeGroup = null;
        private GameObject _policeGroupInstance = null;

        public override void Start()
        {
            this._policeGroupInstance = GameObject.Instantiate(_policeGroup);
            base.Start();
        }

        protected override void FinishAction(bool success)
        {
            if (success)
            {
                GameManager.Instance.FinishPoliceAttack();
            }
            else
            {
                GameManager.Instance.GameOver();
            }

            GameObject.Destroy(this._policeGroupInstance);
            base.FinishAction(success);
        }
    }
}
