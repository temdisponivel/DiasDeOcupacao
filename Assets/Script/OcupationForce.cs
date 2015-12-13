using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Assets.Script
{
    public class OcupationForce : Metric, MonoBehaviour
    {
        private LinkedList<Person> _persons = new LinkedList<Person>();

        void Start()
        {

        }

        void Update()
        {

        }

        public void AddPerson()
        {
            this._persons.AddLast(new Person());
        }

        public void RemovePerson()
        {

        }
    }
}