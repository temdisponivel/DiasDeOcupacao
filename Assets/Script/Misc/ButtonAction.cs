using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Workaround to link a button to the type of action that it perform.
    /// </summary>
    [Serializable]
    public class ButtonAction
    {
        public GameObject _object;
        public Action.ActionPerformer.Actions _actionType;
    }
}
