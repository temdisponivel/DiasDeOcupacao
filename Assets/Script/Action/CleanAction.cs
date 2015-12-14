using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.Action.ActionPerformer
{
    /// <summary>
    /// Class for clean action.
    /// </summary>
    public class CleanAction : ActionPerformer
    {
        protected override void FinishAction(bool success)
        {
            if (success)
            {
                Ocupation.Ocupation.Instance._cleanStatus++;
            }
            else
            {
                Ocupation.Ocupation.Instance._cleanStatus--;
            }
            base.FinishAction(success);
        }
    }
}
