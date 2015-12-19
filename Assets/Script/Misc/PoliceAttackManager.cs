using UnityEngine;
using System.Collections;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Class that manages the police attack
    /// </summary>
    public class PoliceAttackManager : MonoBehaviour
    {
        public GameObject _policeAttack = null;
        public float _secondsToWait = 1;

        void Start()
        {
            this.StartCoroutine(this.WaitToSpawn());
        }

        IEnumerator WaitToSpawn()
        {
            yield return new WaitForSeconds(this._secondsToWait);
            GameObject.Instantiate(this._policeAttack).transform.SetParent(this.gameObject.transform, false);
        }
    }
}