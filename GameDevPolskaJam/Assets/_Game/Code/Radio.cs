using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    [SerializeField] private GameObject fire = null;
    [SerializeField] private PlayMakerFSM fsm = null;
    [SerializeField] private string eventName = "BlinkEnd";

    private bool used;
    
    private void OnCollisionEnter(Collision other)
    {
        if(used) return;
        
        used = true;
        
        if (other.gameObject.tag != "Draggable") return;
        
        fire.SetActive(true);
        GetComponent<AudioSource>().Play();
        
        other.gameObject.SetActive(false);
        //XDDD

        fsm.SendEvent(eventName);
        
        FindObjectOfType<DontDestroyOnLoad>().ChangeToBlokowiskoAUUUUU();
    }
}
