using UnityEngine;
using System.Collections;

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
            if (!OptionsManager.Instance.IsOptOpen)
            {
                OptionsManager.Instance.OpenOption();
            }
        }
    }
}