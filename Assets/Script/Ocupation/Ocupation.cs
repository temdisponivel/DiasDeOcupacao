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
        public int _cleanStatus = 3;
        public int _studyStatus = 3;
        public int _cookStatus = 3;
        public int _startPersonQuantity = 0;
        public int _persons = 0;
        public int _popularAdeptance = 0;

        void Start()
        {
            if (Ocupation.Instance == null)
            {
                Ocupation.Instance = this;
                GameObject.DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                GameObject.Destroy(this.gameObject);
                return;
            }

            this._persons = this._startPersonQuantity;
            GameManager.Instance.AddFinishDayCallback(this.FinishDay);
        }

        /// <summary>
        /// Callback of the finish day event.
        /// </summary>
        public void FinishDay()
        {
            this._imageClean.rectTransform.localScale = new Vector3 { x = this._imageClean.sprite.texture.width * this._cleanStatus, y = this._imageClean.rectTransform.localScale.y, z = this._imageClean.rectTransform.localScale.z };
            this._imageCook.rectTransform.localScale = new Vector3 { x = this._imageCook.sprite.texture.width * this._cookStatus, y = this._imageCook.rectTransform.localScale.y, z = this._imageCook.rectTransform.localScale.z };
            this._imageStudy.rectTransform.localScale = new Vector3 { x = this._imageStudy.sprite.texture.width * this._studyStatus, y = this._imageStudy.rectTransform.localScale.y, z = this._imageStudy.rectTransform.localScale.z };
            this._imagePopularAdeption.rectTransform.localScale = new Vector3 { x = this._imagePopularAdeption.sprite.texture.width * this._popularAdeptance, y = this._imagePopularAdeption.rectTransform.localScale.y, z = this._imagePopularAdeption.rectTransform.localScale.z };
            this._imageDay.rectTransform.localScale = new Vector3 { x = this._imageDay.sprite.texture.width * Day.Number, y = this._imageDay.rectTransform.localScale.y, z = this._imageDay.rectTransform.localScale.z };
        }
    }
}