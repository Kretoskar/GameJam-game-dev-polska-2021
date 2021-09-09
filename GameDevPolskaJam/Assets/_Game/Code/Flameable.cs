using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flameable : MonoBehaviour
{
    
    [SerializeField] private GameObject fire;

    public bool OnFire => fire.activeSelf;
    
    public void StartFire()
    {
        fire.SetActive(true);
    }
}
