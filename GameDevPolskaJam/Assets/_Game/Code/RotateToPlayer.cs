using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] private bool enabledOnStart = true;
    
    private Transform player;

    private bool enabled;

    private void Awake()
    {
        enabled = enabledOnStart;
    }
    
    private void Start()
    {
        player = FindObjectOfType<CharacterController>().transform;
    }
    
    void Update()
    {
        if(!enabled) return;
        
        Vector3 difference = player.position - transform.position;
        double rotY = Math.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, (float)rotY, 0.0f);
    }

    public void EnableRotation() => enabled = true;
    public void Dissableotation() => enabled = false;
    public void ToggleRotation() => enabled = !enabled;
}
