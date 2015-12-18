using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Assets.Script.Misc;


namespace Assets.Script.Ocupation
{
    /// <summary>
    /// Class that represents the ocupation.
    /// </summary>
    public class Ocupation : MonoBehaviour
    {
        static public Ocupation Instance = null;

        public Image _imagePopularAdeption = null;
        public Image _imageClean = null;
        public Image _imageCook = null;
        public Image _imageStudy = null;
        public Image _imageDay = null;

        void Start()
        {
            GameManager.Instance.AddInitiateDayCallback(this.InitiateDay);
        }

        /// <summary>
        /// Callback of the initiate day event.
        /// </summary>
        public void InitiateDay()
        {
            this._imageClean.rectTransform.sizeDelta = new Vector2 { x = this._imageClean.sprite.bounds.size.x * 100 * GameManager.Instance._occupationStatus._cleanStatus, y = this._imageClean.rectTransform.sizeDelta.y };
            this._imageCook.rectTransform.sizeDelta = new Vector2 { x = this._imageCook.sprite.bounds.size.x * 100 * GameManager.Instance._occupationStatus._cookStatus, y = this._imageCook.rectTransform.sizeDelta.y };
            this._imageStudy.rectTransform.sizeDelta = new Vector2 { x = this._imageStudy.sprite.bounds.size.x * 100 * GameManager.Instance._occupationStatus._studyStatus, y = this._imageStudy.rectTransform.sizeDelta.y };
            this._imagePopularAdeption.rectTransform.sizeDelta = new Vector2 { x = this._imagePopularAdeption.sprite.bounds.size.x * 100 * GameManager.Instance._occupationStatus._popularAdeptance, y = this._imagePopularAdeption.rectTransform.sizeDelta.y };
            this._imageDay.rectTransform.sizeDelta = new Vector2 { x = this._imageDay.sprite.bounds.size.x * 100 * Day.Number, y = this._imageDay.rectTransform.sizeDelta.y };
        }
    }
}