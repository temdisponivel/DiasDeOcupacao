using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Script.Ocupation;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Class that manage the HUD of the game.
    /// </summary>
    public class HudManager : MonoBehaviour
    {
        static public HudManager Instance = null;

        public bool IsOptOpen { get; set; }

        public GameObject _options = null;

        public Text _textQuantityPerson = null;
        public Text _textDay = null;
        public Text _textPopularAdeption = null;
        public Text _textOcupationForce = null;

        void Start()
        {
            if (HudManager.Instance == null)
            {
                HudManager.Instance = this;
                GameObject.DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                GameObject.Destroy(this.gameObject);
                return;
            }
        }


        void Update()
        {
            _textDay.text = GameManager.Instance.CurrentDay.ToString();
            _textQuantityPerson.text = Ocupation.Ocupation.Instance._persons.ToString();
            _textOcupationForce.text = Ocupation.Ocupation.Instance._ocupationForce.ToString();
            _textPopularAdeption.text = Ocupation.Ocupation.Instance._popularAdeptance.ToString();
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