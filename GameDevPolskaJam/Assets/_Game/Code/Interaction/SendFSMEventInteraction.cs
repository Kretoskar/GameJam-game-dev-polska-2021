using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interact
{
    public class SendFSMEventInteraction : Interaction
    {
        [SerializeField] private PlayMakerFSM fsm = null;
        [SerializeField] private string eventName = "eventName";
        
        protected override void Interact()
        {
            fsm.SendEvent(eventName);
        }
    }
}