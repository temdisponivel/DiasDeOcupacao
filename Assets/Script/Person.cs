using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script
{
    /// <summary>
    /// Class that represents a person in the ocupation.
    /// </summary>
    [Serializable]
    public class Person
    {
        #region UNITY EDITOR
        public int MinimunRange = 5;
        public int MaxmunRange = 10;
        #endregion

        public Person()
        {
            this.Cleaning = UnityEngine.Random.Range(this.MinimunRange, this.MaxmunRange);
            this.Reading = UnityEngine.Random.Range(this.MinimunRange, this.MaxmunRange);
            this.Cooking = UnityEngine.Random.Range(this.MinimunRange, this.MaxmunRange);

            this.Force = this.Cleaning * UnityEngine.Random.value * this.Reading * UnityEngine.Random.value *
                this.Cooking * UnityEngine.Random.value;
        }

        /// <summary>
        /// The force of this person in ocupation.
        /// </summary>
        public int Force = 0;

        /// <summary>
        /// How much this person can clean.
        /// </summary>
        public int Cleaning { get; set; }

        /// <summary>
        /// How much this person can read.
        /// </summary>
        public int Reading { get; set; }

        /// <summary>
        /// How much this person can cook.
        /// </summary>
        public int Cooking { get; set; }
    }
}
