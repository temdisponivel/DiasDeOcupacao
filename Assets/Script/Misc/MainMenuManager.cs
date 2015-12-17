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
        public Toggle _toggleSound = null;

        public void Play()
        {
            GameManager.Instance.StartGamePlay();
            GameManager.Instance.WithSound = _toggleSound.isOn;
        }
    }
}