using UnityEngine;
using System.Collections;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Class that manages the intro.
    /// </summary>
    public class IntroManager : MonoBehaviour
    {
        void Update()
        {
            if (Input.anyKeyDown)
            {
                FadeManager.Instance.FadeIn();
                this.StartCoroutine(this.WaitToTitle());
            }
        }

        private IEnumerator WaitToTitle()
        {
            yield return new WaitForSeconds(2);
            Application.LoadLevel("Title");
        }
    }
}