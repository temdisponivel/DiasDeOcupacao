using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Script.Misc;
using Assets.Script.Action;
using Assets.Script.News;

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

        public bool LoseForPoliceAttack { get; set; }
        public int _lastDay = 10;
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

            this.WithSound = true;
            this.Day = new Day();
        }

        /// <summary>
        /// Initiate a new day in ocupation.
        /// </summary>
        public void StartDay()
        {
            if (this._occupationStatus.GameOver())
            {
                this.GameOver();
                return;
            }

            this.Day = new Day();
            this.Day.Started = true;

            foreach (var callback in this._initiatedCallbacksDay)
            {
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

            this.ShouldInterview = false;
            if (NewsManager.LastNews._type == News.News.TypeOfNews.Slanderous)
            {
                this.ShouldInterview = true;
            }

            ActionPerformer._upSubstractor += 1f;
        }

        /// <summary>
        /// Finish a day in ocupation.
        /// </summary>
        public void FinishDay()
        {
            PoliceAttackInpector policeAttack = null;
            if (this._indexPoliceDay < this._policeAttackDays.Length && (policeAttack = this._policeAttackDays[this._indexPoliceDay])._day == Day.Number)
            {
                FadeManager.Instance.FadeIn();
                if (Day.Number == this._lastDay)
                {
                    this.StartCoroutine(this.WaitToPoliceAttack());
                    PoliceAttack.SendToWinGame = true;
                    return;
                }
                else if (policeAttack._dependent)
                {
                    if (!this.Day[ActionPerformer.Actions.Interview])
                    {
                        this.StartCoroutine(this.WaitToPoliceAttack());
                    }
                }
                else
                {
                    this.StartCoroutine(this.WaitToPoliceAttack());
                }
                this._indexPoliceDay++;
            }
            this.InternalFinishDay();
        }

        /// <summary>
        /// Make all necessary calls to finish a day.
        /// </summary>
        private void InternalFinishDay()
        {
            FadeManager.Instance.FadeIn();
            this.StartCoroutine(this.WaitToDay());
            this.UpdateStatus();

            foreach (var callback in this._finishCallbacksDay)
            {
                callback();
            }

            if (this._lastDay == Day.Number)
            {
                this.WinGame();
            }
        }

        /// <summary>
        /// Method that update all status in the end of day.
        /// </summary>
        private void UpdateStatus()
        {
            if (!this.Day[ActionPerformer.Actions.Cook])
            {
                this._occupationStatus[OccupationStatus.Metrics.Cook]--;
            }
            else
            {
                this._occupationStatus[OccupationStatus.Metrics.Cook]++;
            }
            if (!this.Day[ActionPerformer.Actions.Clean])
            {
                this._occupationStatus[OccupationStatus.Metrics.Clean]--;
            }
            else
            {
                this._occupationStatus[OccupationStatus.Metrics.Clean]++;
            }

            if (!this.Day[ActionPerformer.Actions.Study])
            {
                this._occupationStatus[OccupationStatus.Metrics.Study]--;
            }
            else
            {
                this._occupationStatus[OccupationStatus.Metrics.Study]++;
            }

            bool popularAdepetionDecrease = false;
            if (this.Day[ActionPerformer.Actions.Interview])
            {
                if (this.ShouldInterview)
                {
                    this._occupationStatus[OccupationStatus.Metrics.PopularAdeption]++;
                }
                else
                {
                    popularAdepetionDecrease = true;
                    this._occupationStatus[OccupationStatus.Metrics.PopularAdeption]--;
                }
            }
            else
            {
                if (this.ShouldInterview)
                {
                    popularAdepetionDecrease = true;
                    this._occupationStatus[OccupationStatus.Metrics.PopularAdeption]--;
                }
            }

            if (this.Day[ActionPerformer.Actions.Protest])
            {
                this._lastProtest = Day.Number;
                if (this.ShouldProtest)
                {
                    this._occupationStatus[OccupationStatus.Metrics.PopularAdeption]++;
                }
                else
                {
                    if (!popularAdepetionDecrease)
                    {
                        this._occupationStatus[OccupationStatus.Metrics.PopularAdeption]--;
                        popularAdepetionDecrease = true;
                    }
                }
            }

            if (NewsManager.LastNews._position == News.News.SideOfTheNews.CounterOcupation && NewsManager.LastNews._type != News.News.TypeOfNews.Slanderous)
            {
                this._occupationStatus[OccupationStatus.Metrics.PopularAdeption]--;
                popularAdepetionDecrease = true;
            }

            if (!popularAdepetionDecrease)
            {
                this._occupationStatus[OccupationStatus.Metrics.PopularAdeption]++;
            }
        }

        /// <summary>
        /// Wait some seconds to initiate another day.
        /// </summary>
        public IEnumerator WaitToDay()
        {
            yield return new WaitForSeconds(this._secondsTransitionDay);
            this.StartDay();
        }

        /// <summary>
        /// Waits the transition seconds bafore send to the police attack scene.
        /// </summary>
        /// <returns></returns>
        public IEnumerator WaitToPoliceAttack()
        {
            yield return new WaitForSeconds(this._secondsTransitionDay);
            Application.LoadLevel("PoliceAttack");
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
        /// Remove a callback to receive message when a day has finish.
        /// </summary>
        /// <param name="action">Callback to call.</param>
        public void RemoveFinishDayCallback(System.Action action)
        {
            _finishCallbacksDay.Remove(action);
        }

        /// <summary>
        /// Remove a callback to receive message when a day has initiated.
        /// </summary>
        /// <param name="action">Callback to call.</param>
        public void RemoveInitiateDayCallback(System.Action action)
        {
            _initiatedCallbacksDay.Remove(action);
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

        /// <summary>
        /// Start the game play.
        /// </summary>
        public void StartGamePlay()
        {
            this.Day.Started = true;
            NewsManager.ShowFirst = true;
            Day.Number = 1;
            ActionPerformer._upSubstractor = 0;
            this.ShouldProtest = true;
            this.ShouldInterview = false;
            PoliceAttack.SendToWinGame = false;
            this.LoseForPoliceAttack = false;
        }

        /// <summary>
        /// Function that reestart the game.
        /// </summary>
        public void RestartGame()
        {
            GameObject.Destroy(this.gameObject);
            Application.LoadLevel("Intro");
        }

        /// <summary>
        /// Function that close the game.
        /// </summary>
        public void CloseGame()
        {
            Application.Quit();
        }
    }
}