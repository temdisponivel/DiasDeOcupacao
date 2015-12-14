using UnityEngine;
using System.Collections;
using Assets.Script.Misc;
using System.Collections.Generic;

namespace Assets.Script.News
{
    /// <summary>
    /// Class that handles the news.
    /// </summary>
    public class NewsManager : MonoBehaviour
    {
        public NewsDictionary[] _newsType = null;
        private Dictionary<News.SideOfTheNews, News> _news = null;
        public bool OnAction { get; set; }
        public News CurrentAction { get; set; }

        void Start()
        {
            this._news = new Dictionary<News.SideOfTheNews, News>();
            foreach (var news in this._newsType)
            {
                this._news.Add(news._type, news._entity);
            }
        }

        void Update()
        {

        }
    }
}