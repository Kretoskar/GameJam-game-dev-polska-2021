using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interact
{
    [RequireComponent(typeof(Collider))]
    public class Interaction : MonoBehaviour
    {
        [SerializeField] protected InteractType interactType;
        [SerializeField] private bool justOnce = true;

        private bool interacted = false;
        private void OnTriggerEnter(Collider other)
        {
            if(justOnce && interacted) return;
            if (interactType != InteractType.TriggerEnter) return;
            if (other.gameObject.tag != "Player") return;

            Interact();
            interacted = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if(justOnce && interacted) return;
            if (interactType != InteractType.TriggerExit) return;
            if (other.gameObject.tag != "Player") return;

            Interact();
            interacted = true;
        }

        private void OnCollisionEnter(Collision other)
        {
            if(justOnce && interacted) return;
            if (interactType != InteractType.Collision) return;
            if (other.gameObject.tag != "Player") return;

            Interact();
            interacted = true;
        }

        protected virtual void Interact()
        {
            print("Interacting");
        }

        protected enum InteractType
        {
            TriggerEnter,
            TriggerExit,
            Collision
        }
    }

}