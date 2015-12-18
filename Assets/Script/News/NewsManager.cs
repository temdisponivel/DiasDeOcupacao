using UnityEngine;
using System.Collections;
using Assets.Script.Misc;
using System.Collections.Generic;
using UnityEngine.UI;
using Assets.Script.Ocupation;

namespace Assets.Script.News
{
    /// <summary>
    /// Class that handles the news.
    /// </summary>
    public class NewsManager : MonoBehaviour
    {
        static public NewsManager Instance = null;

        public int[] _slanderousNewsDay = null;
        public News LastNews { get; set; }
        public News NextNews { get; set; }
        public GameObject _newsObject = null;
        public Text _newsDay = null;
        public Text _newsTitle = null;
        public Text _newsMessage = null;
        public News[] _news = null;
        public News _firstNews = null;
        public News _winNews = null;
        public News _gameOverNews = null;

        private int _slanderousNewsDayIndex = 0;

        private Dictionary<News.SubjectOfTheNews, Dictionary<News.SideOfTheNews, List<News>>> _listNews = new Dictionary<News.SubjectOfTheNews,Dictionary<News.SideOfTheNews,List<News>>>();

        void Start()
        {
            foreach (var news in this._news)
            {
                if (!this._listNews.ContainsKey(news._subject))
                {
                    this._listNews[news._subject] = new Dictionary<News.SideOfTheNews, List<News>>();
                }
                if (!this._listNews[news._subject].ContainsKey(news._position))
                {
                    this._listNews[news._subject][news._position] = new List<News>();
                }

                this._listNews[news._subject][news._position].Add(news);
            }

            if (Day.Number == 1)
            {
                this.ShowFirstNews();
            }

            NewsManager.Instance = this;
            GameManager.Instance.AddInitiateDayCallback(this.InitiateDay);
            GameManager.Instance.AddFinishDayCallback(this.FinishDay);
        }

        /// <summary>
        /// Retuns a random news according with the given subject, position and type.
        /// </summary>
        public News GetNews(News.SubjectOfTheNews subject, News.SideOfTheNews position, News.TypeOfNews type)
        {
            Debug.Log(subject);
            Debug.Log(position);
            Debug.Log(type);
            var list = this._listNews[subject][position];
            return (list = list.FindAll(n => n._type == type))[UnityEngine.Random.Range(0, list.Count - 1)];
        }



        /// <summary>
        /// Shows the first news of the game.
        /// </summary>
        public void ShowFirstNews()
        {
            this.ShowNews(this._firstNews);
        }

        /// <summary>
        /// Shows a news in game.
        /// </summary>
        /// <param name="news">News to show.</param>
        public void ShowNews(News news)
        {
            this._newsDay.text = Day.Number.ToString();
            this._newsTitle.text = news._newsTitle;
            this._newsMessage.text = news._newsMessage;
            this._newsObject.SetActive(true);
            this.LastNews = news;
        }

        /// <summary>
        /// Function for the button that dispose this news.
        /// </summary>
        public void StartActivities()
        {
            this._newsObject.SetActive(false);
        }

        /// <summary>
        /// Function for when a day has been initiated.
        /// </summary>
        public void InitiateDay()
        {
            if (this._slanderousNewsDayIndex < this._slanderousNewsDay.Length && this._slanderousNewsDay[this._slanderousNewsDayIndex] == Day.Number)
            {
                this.ShowNews(this.GetNews(News.SubjectOfTheNews.Ocupation, News.SideOfTheNews.CounterOcupation, News.TypeOfNews.Slanderous));
            }
            else
            {
                this.ShowNews(this.NextNews);
            }
        }

        /// <summary>
        /// Function for when a day has been finished.
        /// </summary>
        public void FinishDay()
        {
            if (GameManager.Instance.Day[Action.ActionPerformer.Actions.Interview])
            {
                if (GameManager.Instance.ShouldInterview)
                {
                    this.NextNews = this.GetNews(News.SubjectOfTheNews.Interview, News.SideOfTheNews.ProOcupation, News.TypeOfNews.Truthful);
                }
                else
                {
                    this.NextNews = this.GetNews(News.SubjectOfTheNews.Interview, News.SideOfTheNews.CounterOcupation, News.TypeOfNews.Truthful);
                }
            }
            else if (GameManager.Instance.Day[Action.ActionPerformer.Actions.Protest])
            {
                if (GameManager.Instance.ShouldProtest)
                {
                    this.NextNews = this.GetNews(News.SubjectOfTheNews.Protest, News.SideOfTheNews.ProOcupation, News.TypeOfNews.Truthful);
                }
                else
                {
                    this.NextNews = this.GetNews(News.SubjectOfTheNews.Protest, News.SideOfTheNews.CounterOcupation, News.TypeOfNews.Truthful);
                }
            }
            else
            {
                if (!GameManager.Instance.Day[Action.ActionPerformer.Actions.Clean] || !GameManager.Instance.Day[Action.ActionPerformer.Actions.Cook] ||
                    !GameManager.Instance.Day[Action.ActionPerformer.Actions.Study])
                {
                    this.NextNews = this.GetNews(News.SubjectOfTheNews.Ocupation, News.SideOfTheNews.CounterOcupation, News.TypeOfNews.Truthful);
                }
                else
                {
                    this.NextNews = this.GetNews(News.SubjectOfTheNews.Ocupation, News.SideOfTheNews.ProOcupation, News.TypeOfNews.Truthful);
                }
            }
        }
    }
}