using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Class that perform the fade in and fade out effect.
    /// </summary>
    public class FadeManager : MonoBehaviour
    {
        static public FadeManager Instance { get; set; }

        public Image _imageFade = null;
        public float _percentPerFrame = 2;

        public void Start()
        {
            FadeManager.Instance = this;
            this.FadeOut();
        }

        /// <summary>
        /// Performs the fade in effect.
        /// </summary>
        public void FadeIn()
        {
            this.StartCoroutine(this.Fade(true));
        }

        /// <summary>
        /// Perform the fade out effect.
        /// </summary>
        public void FadeOut()
        {
            this.StartCoroutine(this.Fade(false));
        }

        private IEnumerator Fade(bool fadein)
        {
            if (fadein)
            {
                this._imageFade.enabled = true;
            }

            for (float i = this._imageFade.color.a, percent = this._percentPerFrame / 100f; fadein ? i <= 1 : i >= 0; i += (fadein ? percent : -percent))
            {
                this._imageFade.color = new Color { r = this._imageFade.color.r, g = this._imageFade.color.g, b = this._imageFade.color.b, a = i };
                yield return 1;
            }

            if (!fadein)
            {
                this._imageFade.enabled = false;
            }
        }
    }
}