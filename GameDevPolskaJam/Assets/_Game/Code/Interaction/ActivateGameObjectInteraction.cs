using System.Collections;
using System.Collections.Generic;
using Game.Interact;
using UnityEngine;

namespace Game.Interact
{
    public class ActivateGameObjectInteraction : Interaction
    {
        [SerializeField] private GameObject target;
        
        protected override void Interact()
        {
            target.SetActive(!target.activeSelf);
        }
    }
}
