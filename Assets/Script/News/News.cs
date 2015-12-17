using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.News
{
    /// <summary>
    /// Class that represents a new in the game.
    /// </summary>
    [Serializable]
    public class News
    {
        /// <summary>
        /// Enumerator that descrives the side of the news toward 
        /// </summary>
        public enum SideOfTheNews
        {
            ProOcupation,
            CounterOcupation,
            Neutral
        }

        /// <summary>
        /// Enumerator for the subject of the news.
        /// </summary>
        public enum SubjectOfTheNews
        {
            Ocupation,
            Protest,
            Interview
        }

        public enum TypeOfNews
        {
            Slanderous,
            Truthful
        }

        public string _newsTitle = "";
        public string _newsMessage = "";
        public SideOfTheNews _position = SideOfTheNews.Neutral;
        public TypeOfNews _type = TypeOfNews.Truthful;
        public SubjectOfTheNews _subject = SubjectOfTheNews.Ocupation;
    }
}
