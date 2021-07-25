using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pala : MonoBehaviour
{
    [SerializeField] private PlayMakerFSM fsm;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject pala;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fsm.SendEvent("Blink");
            animator.SetTrigger("Pala");
            Collider[] hitColliders = Physics.OverlapSphere(pala.transform.position, 1);

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("Palable"))
                {
                    hitCollider.gameObject.GetComponent<Palable>().Spalowany();
                }
            }
        }
    }
}
