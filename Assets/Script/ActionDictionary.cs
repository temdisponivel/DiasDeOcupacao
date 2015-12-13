using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script
{
    /// <summary>
    /// Clever work around for handle dictionary-like data struct in Unity inspector.
    /// </summary>
    [Serializable]
    public class ActionDictionary
    {
        public Action.ActionTypes _type;
        public Action _action;
    }
}
