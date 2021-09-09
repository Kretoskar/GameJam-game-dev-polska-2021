using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    [SerializeField] private AudioClip blokowisko = null;
    [SerializeField] private AudioClip zima = null;
    
    private void Awake() 
    {
        DontDestroyOnLoad(this);
    }

    public void ChangeToZima()
    {
        GetComponent<AudioSource>().clip = zima;
        GetComponent<AudioSource>().Play();
    }
    
    public void ChangeToBlokowiskoAUUUUU()
    {
        GetComponent<AudioSource>().clip = blokowisko;
        
        GetComponent<AudioSource>().Play();
    }
}
