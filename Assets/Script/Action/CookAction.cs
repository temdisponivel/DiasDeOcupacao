using Assets.Script.Occupation;
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
            GameManager.Instance.Day[ActionPerformer.Actions.Cook] = success;
            base.FinishAction(success);
        }
    }
}
