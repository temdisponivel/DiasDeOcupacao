using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Script.Occupation;
using System.Collections.Generic;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Class that handles the game over
    /// </summary>
    public class GameOverManager : MonoBehaviour
    {
        public List<GameOverMessageInspector> _messages;

        public GameOverMessageInspector _messagePoliceAttack = null;

        public Text _textTitle = null;
        public Text _textMessage = null;

        void Start()
        {
            List<Occupation.OccupationStatus.Metrics> _withZero = GameManager.Instance._occupationStatus.MetricsWithZero();
            var messagesInCommon = this._messages.FindAll(m => _withZero.Contains(m._metric));
            if (GameManager.Instance.LoseForPoliceAttack || messagesInCommon.Count == 0)
            {
                this._textTitle.text = _messagePoliceAttack._title;
                this._textMessage.text = _messagePoliceAttack._message;
                return;
            }
            GameOverMessageInspector message = messagesInCommon[Random.Range(0, messagesInCommon.Count)];
            this._textTitle.text = message._title;
            this._textMessage.text = message._message;
        }
    }
}