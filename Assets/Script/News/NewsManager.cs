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
        public GameObject _newsObject = null;
        public Text _newsDay = null;
        public Text _newsTitle = null;
        public Text _newsMessage = null;
        public News[] _news = null;
        public News _firstNews = null;
        public News _lastNews = null;
        public News _gameOverNews = null;

        private Dictionary<News.SubjectOfTheNews, Dictionary<News.SideOfTheNews, List<News>>> _listNews = new Dictionary<News.SubjectOfTheNews,Dictionary<News.SideOfTheNews,List<News>>>();

        void Start()
        {
            foreach (var news in this._news)
            {
                if (this._listNews[news._subject] == null)
                {
                    this._listNews[news._subject] = new Dictionary<News.SideOfTheNews, List<News>>();
                }
                if (this._listNews[news._subject][news._position] == null)
                {
                    this._listNews[news._subject][news._position] = new List<News>();
                }

                this._listNews[news._subject][news._position].Add(news);
            }

            this.ShowFirstNews();
        }

        /// <summary>
        /// Retuns a random news according with the given subject, position and type.
        /// </summary>
        public void ShowNews(News.SubjectOfTheNews subject, News.SideOfTheNews position, News.TypeOfNews type)
        {
            var list = this._listNews[subject][position];
            News news = list.FindAll(n => n._type == type)[UnityEngine.Random.Range(0, list.Count - 1)];
            this.ShowNews(news);
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
        private void ShowNews(News news)
        {
            this._newsDay.text = GameManager.Instance.CurrentDay.ToString();
            this._newsTitle.text = news._newsTitle;
            this._newsMessage.text = news._newsMessage;
            this._newsObject.SetActive(true);
        }

        /// <summary>
        /// Function for the button that dispose this news.
        /// </summary>
        public void StartDay()
        {
            this._newsObject.SetActive(false);
            GameManager.Instance.StartDay();
        }
    }
}