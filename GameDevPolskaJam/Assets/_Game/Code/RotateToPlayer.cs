using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = FindObjectOfType<CharacterController>().transform;
    }
    
    void Update()
    {
        Vector3 difference = player.position - transform.position;
        double rotY = Math.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, (float)rotY, 0.0f);
    }
}
