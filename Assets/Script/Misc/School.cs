using UnityEngine;
using System.Collections;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Class that represents a school.
    /// </summary>
    public class School : MonoBehaviour
    {
        static public School Instance = null;

        void Start()
        {
            if (School.Instance == null)
            {
                School.Instance = this;
                GameObject.DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                GameObject.Destroy(this.gameObject);
            }
        }

        void Update()
        {
            if (Input.GetButtonUp("Cancel"))
            {
                if (HudManager.Instance.IsOptOpen)
                {
                    HudManager.Instance.CloseOption();
                }
            }
        }

        void OnMouseUp()
        {
            if (!HudManager.Instance.IsOptOpen)
            {
                HudManager.Instance.OpenOption();
            }
        }
    }
}