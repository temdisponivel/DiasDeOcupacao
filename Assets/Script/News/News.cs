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
    public class News : MonoBehaviour
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

        public enum TypeOfNews
        {
            Slanderous,
            Truthful
        }

        public string _news = "";
        public Text _text = null;
        public SideOfTheNews _position = SideOfTheNews.Neutral;
        public TypeOfNews _type = TypeOfNews.Truthful;

        void Start()
        {
            _text.text = _news;
        }
    }
}
