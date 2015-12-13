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

        public Text _textQuantityPerson = null;
        public Text _textDay = null;
        public Image _imagePopularAdeption = null;
        public Image _imageOcupationForce = null;

        private float _localScaleStartPopularAdeption = 0f;
        private float _localScaleStartOcupationForce = 0f;

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

            this._localScaleStartOcupationForce = this._imageOcupationForce.rectTransform.localScale.x;
            this._localScaleStartPopularAdeption = this._imagePopularAdeption.rectTransform.localScale.x;
        }


        void Update()
        {
            _textDay.text = GameManager.Instance.CurrentDay.ToString();
            _textQuantityPerson.text = Ocupation.Ocupation.Instance._persons.Count.ToString();

            float percentForce = Ocupation.Ocupation.Instance._ocupationForce / Ocupation.Ocupation.Instance._initialOcupationForce;
            _imageOcupationForce.rectTransform.localScale = new Vector2
            {
                x = this._localScaleStartOcupationForce * percentForce,
                y = this._imageOcupationForce.rectTransform.localScale.y
            };

            percentForce = Ocupation.PopularAdeption.Instance.AdeptionForce / Ocupation.Ocupation.Instance._initialOcupationForce;
            _imageOcupationForce.rectTransform.localScale = new Vector2
            {
                x = this._localScaleStartOcupationForce * percentForce,
                y = this._imageOcupationForce.rectTransform.localScale.y
            };
        }
    }
}