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

        public int _minRangeForcePerson = 5;
        public int _maxRangeForcePerson = 10;
        public int _startPersonQuantity = 0;
        public GameObject _person = null;
        public LinkedList<Person> _persons = new LinkedList<Person>();
        public float _ocupationForce = 0;
        public float _initialOcupationForce = 0;

        public void Start()
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

            for (int i = 0; i < this._startPersonQuantity; i++)
            {
                this.AddPerson();
            }

            this._initialOcupationForce = this._ocupationForce;
        }

        public void Update()
        {

        }

        /// <summary>
        /// Adds a new person to this ocupation.
        /// </summary>
        public void AddPerson()
        {
            Person person = new Person();
            this._ocupationForce += person.Force;
            this._persons.AddLast(person);
        }

        /// <summary>
        /// Removes a person from this ocupation.
        /// </summary>
        public void RemovePerson()
        {
            Person person = this._persons.Last.Value;
            this._ocupationForce -= person.Force;
            this._persons.RemoveLast();
        }
    }
}