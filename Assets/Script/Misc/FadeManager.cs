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
            float percent = this._percentPerFrame / 100f;
            float initial = _imageFade.color.a;
            if (fadein)
            {
                this._imageFade.enabled = true;
                while (initial + percent < 100)
                {
                    initial += percent;
                    this._imageFade.color = new Color { r = this._imageFade.color.r, g = this._imageFade.color.g, b = this._imageFade.color.b, a = initial };
                    yield return 1;
                }
            }
            else
            {
                while (initial - percent > 0)
                {
                    initial -= percent;
                    this._imageFade.color = new Color { r = this._imageFade.color.r, g = this._imageFade.color.g, b = this._imageFade.color.b, a = initial };
                    yield return 1;
                }
                this._imageFade.enabled = false;
            }
        }
    }
}