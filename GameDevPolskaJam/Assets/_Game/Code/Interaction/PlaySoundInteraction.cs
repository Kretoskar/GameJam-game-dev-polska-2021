using System.Collections;
using System.Collections.Generic;
using Game.Interact;
using UnityEngine;

namespace Game.Interact
{
    public class PlaySoundInteraction : Interaction
    {
        [SerializeField] private AudioClip clip = null;

        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();

            if (audioSource == null)
                audioSource = gameObject.AddComponent<AudioSource>();
        }

        protected override void Interact()
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
