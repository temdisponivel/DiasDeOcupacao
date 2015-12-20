using Assets.Script.Occupation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.Action
{
    /// <summary>
    /// Class for clean action.
    /// </summary>
    public class CleanAction : ActionPerformer
    {
        protected override void FinishAction(bool success)
        {
            GameManager.Instance.Day[ActionPerformer.Actions.Clean] = success;
            base.FinishAction(success);
        }
    }
}
