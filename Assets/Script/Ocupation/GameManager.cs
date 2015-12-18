using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Script.Misc;
using Assets.Script.Action;

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

        public GameObject _policeAttack = null;
        public bool WithSound { get; set; }
        public Day Day { get; set; }
        public float _secondsTransitionDay = 2;
        public int _intervalProtest = 3;
        public bool InDay { get; set; }
        public bool ShouldInterview { get; set; }
        public bool ShouldProtest { get; set; }
        public PoliceAttackInpector[] _policeAttackDays = null;
        private int _lastProtest = 0;
        private int _indexPoliceDay = 0;

        public OccupationStatus _occupationStatus;

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

            foreach (var callback in this._initiatedCallbacksDay)
            {
                if (callback == null)
                {
                    continue;
                }
                callback();
            }

            FadeManager.Instance.FadeOut();
            if (Day.Number - this._lastProtest > this._intervalProtest)
            {
                this.ShouldProtest = true;
            }
            else
            {
                this.ShouldProtest = false;
            }

            if (News.NewsManager.Instance.LastNews._type == News.News.TypeOfNews.Slanderous)
            {
                this.ShouldInterview = true;
            }
            else
            {
                this.ShouldInterview = false;
            }
        }

        /// <summary>
        /// Finish a day in ocupation.
        /// </summary>
        public void FinishDay()
        {
            foreach (var callback in this._finishCallbacksDay)
            {
                if (callback == null)
                {
                    continue;
                }
                callback();
            }

            PoliceAttackInpector policeAttack = null;
            if (this._indexPoliceDay < this._policeAttackDays.Length && (policeAttack = this._policeAttackDays[this._indexPoliceDay])._day == Day.Number)
            {
                if (policeAttack._dependent)
                {
                    if (!this.Day[ActionPerformer.Actions.Interview])
                    {
                        GameObject.Instantiate(this._policeAttack);
                    }
                }
                else
                {
                    GameObject.Instantiate(this._policeAttack);
                }
                this._indexPoliceDay++;
            }
            else
            {
                FadeManager.Instance.FadeIn();
                this.StartCoroutine(this.WaitToDay());
            }
            this.UpdateStatus();
        }

        /// <summary>
        /// Callback for when the police attack has finished.
        /// </summary>
        public void FinishPoliceAttack()
        {
            FadeManager.Instance.FadeIn();
            this.StartCoroutine(this.WaitToDay());
        }

        /// <summary>
        /// Method that update all status in the end of day.
        /// </summary>
        private void UpdateStatus()
        {
            if (!this.Day[ActionPerformer.Actions.Cook])
            {
                this._occupationStatus._cookStatus--;
            }
            else
            {
                this._occupationStatus._cookStatus = Mathf.Clamp(this._occupationStatus._cookStatus + 1, 0, this._occupationStatus._maxStatus);
            }
            if (!this.Day[ActionPerformer.Actions.Clean])
            {
                this._occupationStatus._cleanStatus--;
            }
            else
            {
                this._occupationStatus._cleanStatus = Mathf.Clamp(this._occupationStatus._cleanStatus + 1, 0, this._occupationStatus._maxStatus);
            }

            if (!this.Day[ActionPerformer.Actions.Study])
            {
                this._occupationStatus._studyStatus--;
            }
            else
            {
                this._occupationStatus._studyStatus = Mathf.Clamp(this._occupationStatus._studyStatus + 1, 0, this._occupationStatus._maxStatus);
            }

            if (this.Day[ActionPerformer.Actions.Interview])
            {
                if (this.ShouldInterview)
                {
                    this._occupationStatus._popularAdeptance = Mathf.Clamp(this._occupationStatus._popularAdeptance + 1, 0, this._occupationStatus._maxStatus);
                }
                else
                {
                    this._occupationStatus._popularAdeptance--;
                }
            }
            else
            {
                if (this.ShouldInterview)
                {
                    this._occupationStatus._popularAdeptance--;
                }
            }

            if (this.Day[ActionPerformer.Actions.Protest])
            {
                if (this.ShouldProtest)
                {
                    this._occupationStatus._popularAdeptance = Mathf.Clamp(this._occupationStatus._popularAdeptance + 1, 0, this._occupationStatus._maxStatus);
                }
                else
                {
                    this._occupationStatus._popularAdeptance--;
                }
            }
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
            this.Day = new Day();
            this.Day.Started = true;
            ActionPerformer.DifficultyCoefficient = 1;
            Day.Number = 1;
            this.ShouldProtest = true;
            this.ShouldInterview = false;
        }
    }
}