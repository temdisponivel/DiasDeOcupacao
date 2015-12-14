using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.Action.ActionPerformer
{
    /// <summary>
    /// Resist attack of police action
    /// </summary>
    public class ResistAttack : ActionPerformer
    {
        protected override void FinishAction(bool success)
        {
            if (success)
            {
                Ocupation.Ocupation.Instance._cookStatus++;
            }
            else
            {
                Ocupation.Ocupation.Instance._cookStatus--;
            }
            base.FinishAction(success);
        }
    }
}
