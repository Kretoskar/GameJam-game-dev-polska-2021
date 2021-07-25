using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToZimaYeaaaah : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<DontDestroyOnLoad>().ChangeToZima();
    }
}
