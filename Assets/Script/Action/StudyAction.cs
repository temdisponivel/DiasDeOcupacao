using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.Action.ActionPerformer
{
    /// <summary>
    /// Class for study.
    /// </summary>
    public class StudyAction : ActionPerformer
    {
        protected override void FinishAction(bool success)
        {
            if (success)
            {
                Ocupation.Ocupation.Instance._studyStatus++;
            }
            else
            {
                Ocupation.Ocupation.Instance._studyStatus--;
            }
            base.FinishAction(success);
        }
    }
}
