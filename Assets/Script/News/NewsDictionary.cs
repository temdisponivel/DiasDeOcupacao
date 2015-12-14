using Assets.Script.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.News
{
    /// <summary>
    /// Class needed because unity can't handle generics directly, so we create this and will appear on inpectior.
    /// </summary>
    [Serializable]
    public class NewsDictionary : TypeEntityDictionary<News.SideOfTheNews, News>
    {
    }
}