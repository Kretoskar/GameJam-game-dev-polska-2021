using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Audio
{
    public class FootstepsSound : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> audioclips = null;
        [SerializeField] private float timeBetweenFootsteps = 0.5f;
        
        private CharacterController characterController;
        private AudioSource audioSource;
        private float currTime = 0;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            PlayFootsteps();
        }
        
        private void PlayFootsteps()
        {
            currTime += Time.deltaTime;

            if (currTime >= timeBetweenFootsteps)
            {
                currTime = 0;
                if (IsWalking())
                    PlayRandomFootstep();
            }
        }

        private void PlayRandomFootstep()
        {
            if(audioclips == null || audioclips.Count == 0) return;

            var random = new System.Random();
            int index = random.Next(audioclips.Count);
            
            audioSource.PlayOneShot(audioclips[index]);
            
        }
        
        private bool IsWalking()
        {
            return characterController.isGrounded && characterController.velocity.magnitude > .1f;
        }
    }
}