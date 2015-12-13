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
        /// <summary>
        /// Possible reasons for a game over.
        /// </summary>
        public enum GameOverState
        {
            RoomMetric,
            PoliceInvasion
        }

        static public GameManager Instance = null;

        public List<System.Action> _callbacksDay = new List<System.Action>();

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
        /// <param name="state">Reason why this game is over.</param>
        public void GameOver(GameOverState state)
        {
            //TODO: game over
        }
    }
}