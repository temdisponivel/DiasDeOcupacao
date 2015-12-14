using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Script.Misc;

namespace Assets.Script.Action
{
    /// <summary>
    /// Class that manage all types of actions in game.
    /// </summary>
    public class ActionManager : MonoBehaviour
    {
        static public ActionManager Instance = null;

        public bool OnAction { get; set; }
        public ActionPerformer.ActionPerformer CurrentAction { get; set; }

        void Start()
        {
            if (ActionManager.Instance == null)
            {
                ActionManager.Instance = this;
                GameObject.DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                GameObject.Destroy(this.gameObject);
            }

        }

        void Update()
        {

        }

        public void StartAction(GameObject action)
        {
            (this.CurrentAction = GameObject.Instantiate(action).GetComponent<ActionPerformer.ActionPerformer>()).SetCallback(this.FinishAction);
            HudManager.Instance.CloseOption();
        }

        public void FinishAction()
        {

        }
    }
}