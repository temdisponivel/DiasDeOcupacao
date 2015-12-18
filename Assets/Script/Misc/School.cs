using UnityEngine;
using System.Collections;
using Assets.Script.Action;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Class that represents a school.
    /// </summary>
    public class School : MonoBehaviour
    {
        void FixedUpdate()
        {
            if (Input.GetButtonUp("Cancel"))
            {
                if (OptionsManager.Instance.IsOptOpen)
                {
                    OptionsManager.Instance.CloseOption();
                }
            }
        }

        void OnMouseUp()
        {
            if (!OptionsManager.Instance.IsOptOpen && !ActionPerformer.InAction)
            {
                OptionsManager.Instance.OpenOption();
            }
        }
    }
}