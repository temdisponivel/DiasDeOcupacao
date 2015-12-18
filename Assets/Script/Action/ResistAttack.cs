using Assets.Script.Ocupation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.Action
{
    /// <summary>
    /// Resist attack of police action
    /// </summary>
    public class ResistAttack : ActionPerformer
    {
        protected override void FinishAction(bool success)
        {
            if (!success)
            {
                GameManager.Instance.GameOver();
            }
            base.FinishAction(success);
        }
    }
}
