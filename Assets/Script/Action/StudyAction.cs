using Assets.Script.Ocupation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.Action
{
    /// <summary>
    /// Class for study.
    /// </summary>
    public class StudyAction : ActionPerformer
    {
        protected override void FinishAction(bool success)
        {
            GameManager.Instance.Day[ActionPerformer.Actions.Study] = success;
            base.FinishAction(success);
        }
    }
}
