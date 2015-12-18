using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.Action
{
    /// <summary>
    /// Class for cook action.
    /// </summary>
    public class CookAction : ActionPerformer
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
