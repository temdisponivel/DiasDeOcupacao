﻿using UnityEngine;
using System.Collections;
using Assets.Script.Occupation;
using Assets.Script.Misc;

namespace Activities
{
    /// <summary>
    /// Class that manages a activitie like a protest and interview.
    /// </summary>
    public class ActivitiesManager : MonoBehaviour
    {
        public int _transitionSeconds = 1;
        public GameObject _groupOne = null;
        public GameObject _groupTwo = null;
        public GameObject _groupThree = null;
        
        void Start()
        {
            switch (GameManager.Instance._occupationStatus[OccupationStatus.Metrics.PopularAdeption])
            {
                case 1:
                    _groupTwo.SetActive(false);
                    _groupThree.SetActive(false);
                    break;
                case 2:
                    _groupThree.SetActive(false);
                    break;
                default:
                    break;
            }
        }

        void Update()
        {
            if (Input.GetButtonDown("Submit"))
            {
                this.Finish(GameManager.Instance._occupationStatus[OccupationStatus.Metrics.PopularAdeption]);
            }
            if (Input.GetButton("Jump"))
            {
                this.GetComponent<Animator>().speed = 2;
            }
            else
            {
                this.GetComponent<Animator>().speed = 1;
            }
        }

        /// <summary>
        /// Function that finish this activity.
        /// </summary>
        public void Finish(int group)
        {
            if (group == GameManager.Instance._occupationStatus[OccupationStatus.Metrics.PopularAdeption])
            {
                FadeManager.Instance.FadeIn();
                this.StartCoroutine(this.WaitToReturn());
            }
        }
        
        /// <summary>
        /// Function that wait some seconds before return to the school scene.
        /// </summary>
        /// <returns></returns>
        private IEnumerator WaitToReturn()
        {
            yield return new WaitForSeconds(this._transitionSeconds);
            Application.LoadLevel("School");
        }
    }
}
