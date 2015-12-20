using UnityEngine;
using System.Collections;
using Assets.Script.Ocupation;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Class that manages a menu for reestar and quit the game.
    /// </summary>
    public class RestartQuitMenu : MonoBehaviour
    {
        /// <summary>
        /// Reestart the game.
        /// </summary>
        public void Reestart()
        {
            GameManager.Instance.RestartGame();
        }

        /// <summary>
        /// Quit game
        /// </summary>
        public void QuitGame()
        {
            GameManager.Instance.CloseGame();
        }
    }
}