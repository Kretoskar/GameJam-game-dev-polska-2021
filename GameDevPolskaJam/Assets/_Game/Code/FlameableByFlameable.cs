using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameableByFlameable : MonoBehaviour
{
    [SerializeField] private GameObject fire = null;
    [SerializeField] private bool destroyFireSource = true;

    private GameObject fireSource = null;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Draggable") return;
        
        var fire = other.GetComponent<Flameable>();
        if(fire == null || !fire.OnFire) return;

        fireSource = other.gameObject;
        
        StartFire();
    }

    private void StartFire()
    {
        fire.SetActive(true);
        
        if(destroyFireSource)
            fireSource.SetActive(false);
        
        GetComponent<PlayMakerFSM>().SendEvent("Fire");
    }
}