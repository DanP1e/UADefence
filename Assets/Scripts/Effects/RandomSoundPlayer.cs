using InspectorAddons;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public class RandomSoundPlayer : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> _sounds;
        [SerializeField] private InterfaceComponent<ISoundHandler> _soundHandler;

        public void PlayRandomSound() 
        {
            _soundHandler.Interface.HandleSound(_sounds[Random.Range(0, _sounds.Count)]);
        }
    }
}
