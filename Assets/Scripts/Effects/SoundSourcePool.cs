using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public struct SourceInfo 
    {
        public AudioSource AudioSource;
        public bool IsBusy;

        public SourceInfo(AudioSource audioSource, bool isBusy)
        {
            AudioSource = audioSource;
            IsBusy = isBusy;
        }
    }
    public class SoundSourcePool : MonoBehaviour, ISoundHandler
    {
        [SerializeField] private List<AudioSource> _audioSources;

        private int _lastSourceId = 0;
        private List<SourceInfo> _sourcesInfo;

        private void Awake()
        {
            _sourcesInfo = new List<SourceInfo>();

            for (int i = 0; i < _audioSources.Count; i++)
                _sourcesInfo.Add(new SourceInfo(_audioSources[i], false));
        }      
        private IEnumerator PlaySoundInFreeSource(AudioClip clip)
        {
            int sourceId = -1;
            SourceInfo info = new SourceInfo();
            for (int i = 0; i < _sourcesInfo.Count; i++)
            {
                if (!_sourcesInfo[i].IsBusy)
                {
                    info = _sourcesInfo[i];
                    info.IsBusy = true;
                    _sourcesInfo[i] = info;
                    info.AudioSource.clip = clip;
                    info.AudioSource.Play();
                    sourceId = i;
                    break;
                }
            }

            if (sourceId == -1)
                yield return null;

            yield return new WaitForSecondsRealtime(clip.length);

            info.IsBusy = false;
            if(sourceId < _sourcesInfo.Count
               && sourceId >= 0)
                _sourcesInfo[sourceId] = info;
        }
        [ContextMenu("Load local audio sources")]
        private void LoadLocalSources() 
        {
            _audioSources = new List<AudioSource>(GetComponents<AudioSource>());
        }

        public void HandleSound(AudioClip clip)
        {
            StartCoroutine(PlaySoundInFreeSource(clip));
        }
    }
}
