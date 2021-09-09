using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interact
{
    public class ChangeMaterialInteraction : Interaction
    {
        [SerializeField] private GameObject target;
        [SerializeField] private Material targetMaterial;
        
        protected override void Interact()
        {
            target.GetComponent<MeshRenderer>().material = targetMaterial;
        }
    }
}
