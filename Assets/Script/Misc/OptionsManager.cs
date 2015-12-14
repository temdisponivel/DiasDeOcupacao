using UnityEngine;
using System.Collections;
using Assets.Script.Action;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Class that manage the options of the games.
    /// </summary>
    public class OptionsManager : MonoBehaviour
    {
        /// <summary>
        /// Give a interview.
        /// </summary>
        public void OptionSelected(GameObject action)
        {
            ActionManager.Instance.StartAction(action);
        }
    }
}