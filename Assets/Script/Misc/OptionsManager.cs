using UnityEngine;
using System.Collections;
using Assets.Script.Action;
using Assets.Script.Ocupation;
using UnityEngine.UI;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Class that manage the options of the games.
    /// </summary>
    public class OptionsManager : MonoBehaviour
    {
        static public OptionsManager Instance = null;

        public int _transitionSeconds = 1;

        public bool IsOptOpen { get; set; }
        public GameObject _options = null;

        void Start()
        {
            OptionsManager.Instance = this;
        }
        
        /// <summary>
        /// Give a interview.
        /// </summary>
        public void OptionSelected(GameObject action)
        {
            this.CloseOption();
            GameObject.Instantiate(action);
        }

        /// <summary>
        /// Call a protest.
        /// </summary>
        public void Protest()
        {
            FadeManager.Instance.FadeIn();
            this.StartCoroutine(this.WaitToReturn("Protest"));
        }

        /// <summary>
        /// Give a interview.
        /// </summary>
        public void Interview()
        {
            FadeManager.Instance.FadeIn();
            this.StartCoroutine(this.WaitToReturn("Interview"));
        }

        /// <summary>
        /// Function that wait some seconds before return to the school scene.
        /// </summary>
        /// <returns></returns>
        private IEnumerator WaitToReturn(string sceneToLoad)
        {
            yield return new WaitForSeconds(this._transitionSeconds);
            Application.LoadLevel(sceneToLoad);
        }

        /// <summary>
        /// Make the option context open.
        /// </summary>
        public void OpenOption()
        {
            _options.SetActive(true);
            this.IsOptOpen = true;
        }

        /// <summary>
        /// Make the option context open.
        /// </summary>
        public void CloseOption()
        {
            _options.SetActive(false);
            this.IsOptOpen = false;
        }
    }
}