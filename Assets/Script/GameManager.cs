using UnityEngine;
using System.Collections;

namespace Assets.Script
{
    /// <summary>
    /// Class that hold usefull information about mechanics and stuff.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        static public GameManager Instance = null;

        public int _secondsPerDay = 1;
        public int CurrentDay { get; set; }

        private float _startDayTime = 0f;
        private float _elapseDayTime = 0f;
        private bool _inDay = false;

        void Start()
        {
            if (GameManager.Instance == null)
            {
                GameManager.Instance = this;
                GameObject.DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                GameObject.Destroy(this.gameObject);
            }
        }

        void Update()
        {
            if (this._inDay)
            {
                if (this._elapseDayTime - this._startDayTime >= this._secondsPerDay)
                {
                    this.FinishDay();
                }
                else
                {
                    this._elapseDayTime += Time.deltaTime;
                }
            }
        }

        /// <summary>
        /// Initiate a new day in ocupation.
        /// </summary>
        public void StartDay()
        {
            this._startDayTime = Time.time;
            this._inDay = true;
        }

        /// <summary>
        /// Finish a day in ocupation.
        /// </summary>
        public void FinishDay()
        {
            this._startDayTime = 0;
            this._inDay = false;
            this._elapseDayTime = 0;
        }
    }
}