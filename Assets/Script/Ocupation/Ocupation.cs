using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Assets.Script.Ocupation
{
    /// <summary>
    /// Class that represents the ocupation.
    /// </summary>
    public class Ocupation : MonoBehaviour
    {
        static public Ocupation Instance = null;

        public int _cleanStatus = 3;
        public int _studyStatus = 3;
        public int _cookStatus = 3;
        public int _startPersonQuantity = 0;
        public int _persons = 0;
        public float _ocupationForce = 0;
        public float _popularAdeptance = 0;
        private float _lastPopularAdeptance = 0;
        private float _lastOcupanceForce = 0;
        private float _lastCleanStatus = 0;
        private float _lastStudyStatus = 0;
        private float _lastCookStatus = 0;

        void Start()
        {
            if (Ocupation.Instance == null)
            {
                Ocupation.Instance = this;
                GameObject.DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                GameObject.Destroy(this.gameObject);
                return;
            }

            this._persons = this._startPersonQuantity;
            GameManager.Instance.AddDayCallback(this.FinishDay);
        }

        /// <summary>
        /// Callback of the finish day event.
        /// </summary>
        public void FinishDay()
        {
            if (this._lastPopularAdeptance < this._popularAdeptance)
            {
                this.IncreasePopularAdeptance();
            }
            else
            {
                this.DescreasePopularAdeptance();
            }

            if (this._lastOcupanceForce < this._ocupationForce)
            {
                this.IncreaseOcupanceForce();
            }
            else
            {
                this.DescreaseOcupanceForce();
            }

            if (this._lastCleanStatus < this._cleanStatus)
            {
                this.IncreaseCleanStatus();
            }
            else
            {
                this.DescreaseCleanStatus();
            }

            if (this._lastStudyStatus < this._studyStatus)
            {
                this.IncreaseStudyStatus();
            }
            else
            {
                this.DescreaseCleanStatus();
            }

            if (this._lastCookStatus < this._cookStatus)
            {
                this.IncreaseCookStatus();
            }
            else
            {
                this.DescreaseCleanStatus();
            }

            this._lastPopularAdeptance = this._popularAdeptance;
            this._lastOcupanceForce = this._ocupationForce;
            this._lastCleanStatus = this._cleanStatus;
            this._lastCookStatus = this._cookStatus;
            this._lastStudyStatus = this._studyStatus;
        }

        /// <summary>
        /// Funcion for when the popular adeptance decrease.
        /// </summary>
        private void DescreasePopularAdeptance()
        {
        }

        /// <summary>
        /// Funcion for when the popular adeptance increase.
        /// </summary>
        private void IncreasePopularAdeptance()
        {
        }

        /// <summary>
        /// Funcion for when the popular adeptance decrease.
        /// </summary>
        private void DescreaseOcupanceForce()
        {
        }

        /// <summary>
        /// Funcion for when the popular adeptance increase.
        /// </summary>
        private void IncreaseOcupanceForce()
        {
        }

        /// <summary>
        /// Funcion for when the popular adeptance decrease.
        /// </summary>
        private void DescreaseCookStatus()
        {
        }

        /// <summary>
        /// Funcion for when the popular adeptance increase.
        /// </summary>
        private void IncreaseCookStatus()
        {
        }

        /// <summary>
        /// Funcion for when the popular adeptance decrease.
        /// </summary>
        private void DescreaseCleanStatus()
        {
        }

        /// <summary>
        /// Funcion for when the popular adeptance increase.
        /// </summary>
        private void IncreaseCleanStatus()
        {
        }

        /// <summary>
        /// Funcion for when the popular adeptance decrease.
        /// </summary>
        private void DescreaseStudyStatus()
        {
        }

        /// <summary>
        /// Funcion for when the popular adeptance increase.
        /// </summary>
        private void IncreaseStudyStatus()
        {
        }
    }
}