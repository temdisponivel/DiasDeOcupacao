using UnityEngine;
using System.Collections;
using Assets.Script.Action;
using Assets.Script.Ocupation;
using UnityEngine.UI;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Class that manage the options of the games.
    /// </summary>
    public class OptionsManager : MonoBehaviour
    {
        static public OptionsManager Instance = null;

        public int _transitionSeconds = 1;

        public bool IsOptOpen { get; set; }
        public GameObject _options = null;

        public ButtonAction[] _buttonAction;

        void Start()
        {
            OptionsManager.Instance = this;
            GameManager.Instance.AddInitiateDayCallback(this.InitiateDayCallback);
            this.UpdateShowingButtons();
        }

        /// <summary>
        /// Update the buttons that is to be displayed.
        /// </summary>
        private void UpdateShowingButtons()
        {
            foreach (var button in this._buttonAction)
            {
                if (GameManager.Instance.Day.HasPerformed(button._actionType))
                {
                    button._object.SetActive(false);
                }
            }
        }
        
        /// <summary>
        /// Give a interview.
        /// </summary>
        public void OptionSelected(GameObject action)
        {
            ActionPerformer.Actions type = action.GetComponent<ActionPerformer>()._type;
            GameObject.Instantiate(action).transform.SetParent(this.gameObject.transform, false);

            foreach (var button in this._buttonAction)
            {
                if (button._actionType == type)
                {
                    button._object.SetActive(false);
                    break;
                }
            }
        }

        /// <summary>
        /// Call a protest.
        /// </summary>
        public void Protest()
        {
            FadeManager.Instance.FadeIn();
            this.StartCoroutine(this.WaitToReturn("Protest"));
            foreach (var button in this._buttonAction)
            {
                if (button._actionType == ActionPerformer.Actions.Protest)
                {
                    button._object.SetActive(false);
                    break;
                }
            }
            GameManager.Instance.Day[ActionPerformer.Actions.Protest] = true;
        }

        /// <summary>
        /// Give a interview.
        /// </summary>
        public void Interview()
        {
            FadeManager.Instance.FadeIn();
            this.StartCoroutine(this.WaitToReturn("Interview"));
            foreach (var button in this._buttonAction)
            {
                if (button._actionType == ActionPerformer.Actions.Interview)
                {
                    button._object.SetActive(false);
                    break;
                }
            }
            GameManager.Instance.Day[ActionPerformer.Actions.Interview] = true;
        }

        /// <summary>
        /// Finish this day.
        /// </summary>
        public void FinishDay()
        {
            GameManager.Instance.FinishDay();
        }

        /// <summary>
        /// Function that wait some seconds before return to the school scene.
        /// </summary>
        /// <returns></returns>
        private IEnumerator WaitToReturn(string sceneToLoad)
        {
            yield return new WaitForSeconds(this._transitionSeconds);
            Application.LoadLevel(sceneToLoad);
        }

        /// <summary>
        /// Make the option context open.
        /// </summary>
        public void OpenOption()
        {
            _options.SetActive(true);
            this.IsOptOpen = true;
        }

        /// <summary>
        /// Make the option context open.
        /// </summary>
        public void CloseOption()
        {
            if (_options != null)
            {
                _options.SetActive(false);
                this.IsOptOpen = false;
            }
        }

        /// <summary>
        /// Callback for when a new day is initiated.
        /// </summary>
        public void InitiateDayCallback()
        {
            foreach (var button in this._buttonAction)
            {
                button._object.SetActive(true);
            }
        }
    }
}