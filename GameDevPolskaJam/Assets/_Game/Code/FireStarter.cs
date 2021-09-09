using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStarter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Draggable") return;
        
        var fire = other.GetComponent<Flameable>();
        if(fire == null) return;
        
        fire.StartFire();
    }
}
