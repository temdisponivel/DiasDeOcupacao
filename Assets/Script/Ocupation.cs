using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Assets.Script
{
    /// <summary>
    /// Class that represents the ocupation.
    /// </summary>
    public class Ocupation : MonoBehaviour
    {
        public int _startPersonQuantity = 0;
        public GameObject _person = null;
        private LinkedList<Person> _persons = new LinkedList<Person>();
        private float _ocupationForce = 0;

        public void Start()
        {
            for (int i = 0; i < this._startPersonQuantity; i++)
            {
                this.AddPerson();
            }
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