using UnityEngine;
using System.Collections;
using Assets.Script.Ocupation;

namespace Assets.Script.Misc
{
    /// <summary>
    /// Class that manage sounds.
    /// </summary>
    public class SoundManager : MonoBehaviour
    {
        public AudioSource[] _audios = null;
        
        public void Start()
        {
            
            foreach (var sound in _audios)
            {
                if (GameManager.Instance.WithSound)
                {
                    sound.Play();
                }
                else
                {
                    sound.Pause();
                }
            }
        }
    }
}