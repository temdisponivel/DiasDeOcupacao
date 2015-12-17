using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Script.Misc;

namespace Assets.Script.Ocupation
{
    /// <summary>
    /// Class that hold usefull information about mechanics and stuff.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        static public GameManager Instance = null;

        public List<System.Action> _finishCallbacksDay = new List<System.Action>();
        public List<System.Action> _initiatedCallbacksDay = new List<System.Action>();

        public int _secondsPerDay = 1;
        public bool WithSound { get; set; }
        public Day Day { get; set; }
        public float _secondsTransitionDay = 2;
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

        /// <summary>
        /// Initiate a new day in ocupation.
        /// </summary>
        public void StartDay()
        {
            this.Day = new Day();
            this.Day.Started = true;
            FadeManager.Instance.FadeOut();

            foreach (var callback in this._initiatedCallbacksDay)
            {
                callback();
            }
        }

        /// <summary>
        /// Finish a day in ocupation.
        /// </summary>
        public void FinishDay()
        {
            foreach (var callback in this._finishCallbacksDay)
            {
                callback();
            }

            FadeManager.Instance.FadeIn();
            this.StartCoroutine(this.WaitToDay());
        }

        /// <summary>
        /// Wait some seconds to initiate another day.
        /// </summary>
        public IEnumerator WaitToDay()
        {
            yield return new WaitForSeconds(this._secondsTransitionDay);
            this.StartDay();
            FadeManager.Instance.FadeOut();
        }

        /// <summary>
        /// Add a callback to receive message when a day has finish.
        /// </summary>
        /// <param name="action">Callback to call.</param>
        public void AddFinishDayCallback(System.Action action)
        {
            _finishCallbacksDay.Add(action);
        }

        /// <summary>
        /// Add a callback to receive message when a day has initiated.
        /// </summary>
        /// <param name="action">Callback to call.</param>
        public void AddInitiateDayCallback(System.Action action)
        {
            _initiatedCallbacksDay.Add(action);
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
            this.Day = new Day();
            this.Day.Started = true;
            Action.ActionPerformer.ActionPerformer.DifficultyCoefficient = 1;
        }
    }
}