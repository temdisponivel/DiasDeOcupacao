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

        public List<GameObject> _groups = null;

        public Image _imagePopularAdeption = null;
        public Image _imageClean = null;
        public Image _imageCook = null;
        public Image _imageStudy = null;
        public Image _imageDay = null;

        static private int _lastPopularAdeption = 0;
        
        void Start()
        {
            Ocupation.Instance = this;
            GameManager.Instance.AddInitiateDayCallback(this.InitiateDay);
            this.InitiateDay();
        }

        /// <summary>
        /// Callback of the initiate day event.
        /// </summary>
        public void InitiateDay()
        {
            this._imageClean.rectTransform.sizeDelta = new Vector2 { x = this._imageClean.sprite.bounds.size.x * 100 * GameManager.Instance._occupationStatus[OccupationStatus.Metrics.Clean], y = this._imageClean.rectTransform.sizeDelta.y };
            this._imageCook.rectTransform.sizeDelta = new Vector2 { x = this._imageCook.sprite.bounds.size.x * 100 * GameManager.Instance._occupationStatus[OccupationStatus.Metrics.Cook], y = this._imageCook.rectTransform.sizeDelta.y };
            this._imageStudy.rectTransform.sizeDelta = new Vector2 { x = this._imageStudy.sprite.bounds.size.x * 100 * GameManager.Instance._occupationStatus[OccupationStatus.Metrics.Study], y = this._imageStudy.rectTransform.sizeDelta.y };
            this._imagePopularAdeption.rectTransform.sizeDelta = new Vector2 { x = this._imagePopularAdeption.sprite.bounds.size.x * 100 * GameManager.Instance._occupationStatus[OccupationStatus.Metrics.PopularAdeption], y = this._imagePopularAdeption.rectTransform.sizeDelta.y };
            this._imageDay.rectTransform.sizeDelta = new Vector2 { x = this._imageDay.sprite.bounds.size.x * 100 * Day.Number, y = this._imageDay.rectTransform.sizeDelta.y };

            bool status = true;
            var groups = this._groups.FindAll(g => g.activeSelf == false);
            if (Ocupation._lastPopularAdeption > GameManager.Instance._occupationStatus[OccupationStatus.Metrics.PopularAdeption])
            {
                groups = this._groups.FindAll(g => g.activeSelf == true);
                status = false;                
            }

            if (groups.Count > 0)
            {
                groups[UnityEngine.Random.Range(0, groups.Count)].SetActive(status);
            }

            Ocupation._lastPopularAdeption = GameManager.Instance._occupationStatus[OccupationStatus.Metrics.PopularAdeption];
        }

        public void OnDestroy()
        {
            GameManager.Instance.RemoveInitiateDayCallback(this.InitiateDay);
        }
    }
}