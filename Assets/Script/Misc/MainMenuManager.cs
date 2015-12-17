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

        public void Play()
        {
            GameManager.Instance.StartGamePlay();
            GameManager.Instance.WithSound = _sound;
        }

        public void Toggle(bool state)
        {
            this._sound = state;
        }
    }
}