using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Script.Ocupation;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Class that manages the main menu of the game.
    /// </summary>
    public class MainMenuManager : MonoBehaviour
    {
        public bool _sound = false;
        public int _transitionSeconds = 1;

        /// <summary>
        /// Function that finish this activity.
        /// </summary>
        public void Play()
        {
            GameManager.Instance.WithSound = _sound;
            FadeManager.Instance.FadeIn();
            this.StartCoroutine(this.WaitToReturn());
        }

        /// <summary>
        /// Function that wait some seconds before return to the school scene.
        /// </summary>
        /// <returns></returns>
        private IEnumerator WaitToReturn()
        {
            yield return new WaitForSeconds(this._transitionSeconds);
            GameManager.Instance.StartGamePlay();
            Application.LoadLevel("School");
        }

        public void Toggle(bool state)
        {
            this._sound = state;
        }
    }
}