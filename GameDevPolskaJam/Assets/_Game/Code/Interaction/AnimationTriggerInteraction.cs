using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interact
{
    public class AnimationTriggerInteraction : Interaction
    {
        [SerializeField] private string eventName = "";
        [SerializeField] private Animator animator = null;

        protected override void Interact()
        {
            animator.SetTrigger(eventName);
        }
    }

}