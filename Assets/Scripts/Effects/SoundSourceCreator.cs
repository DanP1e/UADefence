using System;
using System.Collections;
using UnityEngine;

namespace Effects
{
    public class SoundSourceCreator : MonoBehaviour, ISoundHandler
    {
        [Tooltip("Новые источники звука будут создаваться " +
            "на основе этого компонента. Будут копировать его параметры.")]
        [SerializeField] private AudioSource _sourceExample;
        public void HandleSound(AudioClip clip)
        {
            if (_sourceExample == null)
                throw new NullReferenceException($"{nameof(AudioSource)} in {nameof(_sourceExample)} field is null!");

            StartCoroutine(PlaySoundAsNewSource(clip));
        }

        private IEnumerator PlaySoundAsNewSource(AudioClip clip)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.priority = _sourceExample.priority;
            audioSource.pitch = _sourceExample.pitch;
            audioSource.volume = _sourceExample.volume;
            audioSource.panStereo = _sourceExample.panStereo;
            audioSource.spatialBlend = _sourceExample.spatialBlend;
            audioSource.reverbZoneMix = _sourceExample.reverbZoneMix;
            audioSource.bypassEffects = _sourceExample.bypassEffects;
            audioSource.bypassListenerEffects = _sourceExample.bypassListenerEffects;
            audioSource.bypassReverbZones = _sourceExample.bypassReverbZones;
            audioSource.Play();
            yield return new WaitForSecondsRealtime(clip.length);
            Destroy(audioSource);
        }
    }
}
