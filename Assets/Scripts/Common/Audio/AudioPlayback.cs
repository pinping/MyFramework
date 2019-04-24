using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework {

    public class AudioPlayback : DDOLSingleton<AudioPlayback> {

        public AudioSource audioSource;

        private void Awake() {
            if (audioSource == null) {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        void Play(AudioClip musicClip,bool loop = false) {
            audioSource.Stop();
            audioSource.clip = musicClip;
            audioSource.loop = loop;
            audioSource.Play();
        }

        void PlayOne(AudioClip musicClip) {
            audioSource.PlayOneShot(musicClip);
        }

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }
}
