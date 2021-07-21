using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interact
{
    [RequireComponent(typeof(Collider))]
    public class Interaction : MonoBehaviour
    {
        [SerializeField] protected InteractType interactType;

        private void OnTriggerEnter(Collider other)
        {
            if (interactType != InteractType.TriggerEnter) return;
            if (other.gameObject.tag != "Player") return;

            Interact();
        }

        private void OnTriggerExit(Collider other)
        {
            if (interactType != InteractType.TriggerExit) return;
            if (other.gameObject.tag != "Player") return;

            Interact();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (interactType != InteractType.Collision) return;
            if (other.gameObject.tag != "Player") return;

            Interact();
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