using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Handy class to aux decide which message should be shown in the game over scene.
    /// </summary>
    [Serializable]
    public class GameOverMessageInspector
    {
        public string _title;
        public string _message;
        public Ocupation.OccupationStatus.Metrics _metric;
    }
}
