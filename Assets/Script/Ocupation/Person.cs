using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.Ocupation
{
    /// <summary>
    /// Class that represents a person in the ocupation.
    /// </summary>
    [Serializable]
    public class Person
    {
        /// <summary>
        /// The force of this person in ocupation.
        /// </summary>
        public float Force = 0;

        public Person()
        {
            this.Force = UnityEngine.Random.Range(Ocupation.Instance._minRangeForcePerson, Ocupation.Instance._maxRangeForcePerson);
        }
    }
}
