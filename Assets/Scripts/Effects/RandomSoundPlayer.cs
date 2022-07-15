using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Effects
{
    public class RandomSoundPlayer : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> _sounds;
        [SerializeField] private ISoundHandler _soundHandler;

        [Inject]
        public void Construct(ISoundHandler soundHandler) 
        {
            _soundHandler = soundHandler;
        }

        public void PlayRandomSound() 
        {
            _soundHandler.HandleSound(_sounds[Random.Range(0, _sounds.Count)]);
        }
    }
}
