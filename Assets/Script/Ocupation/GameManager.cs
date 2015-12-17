using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Script.Ocupation
{
    /// <summary>
    /// Class that hold usefull information about mechanics and stuff.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        static public GameManager Instance = null;

        public List<System.Action> _callbacksDay = new List<System.Action>();

        public int _secondsPerDay = 1;
        public bool WithSound { get; set; }
        public int CurrentDay { get; set; }
        private float _startDayTime = 0f;
        private float _elapseDayTime = 0f;
        public bool InDay { get; set; }

        void Awake()
        {
            if (GameManager.Instance == null)
            {
                GameManager.Instance = this;
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
            if (this.InDay)
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
            this.InDay = true;
        }

        /// <summary>
        /// Finish a day in ocupation.
        /// </summary>
        public void FinishDay()
        {
            this._startDayTime = 0;
            this.InDay = false;
            this._elapseDayTime = 0;

            foreach (var callback in this._callbacksDay)
            {
                callback();
            }
        }

        /// <summary>
        /// Add a callback to receive message when a day has finish.
        /// </summary>
        /// <param name="action">Callback to call.</param>
        public void AddDayCallback(System.Action action)
        {
            _callbacksDay.Add(action);
        }

        /// <summary>
        /// End this game with a given state.
        /// </summary>
        public void GameOver()
        {
            Application.LoadLevel("GameOver");
        }
        
        /// <summary>
        /// Finish game and send to the winner scene.
        /// </summary>
        public void WinGame()
        {
            Application.LoadLevel("WinGame");
        }

        public void StartGamePlay()
        {
            Application.LoadLevel("School");
            this.CurrentDay = 1;
            this._startDayTime = 0;
            this.InDay = false;
        }
    }
}