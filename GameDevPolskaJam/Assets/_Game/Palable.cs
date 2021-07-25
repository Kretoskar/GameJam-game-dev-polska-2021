using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Palable : MonoBehaviour
{
    [SerializeField] private GameObject blood = null;
    [SerializeField] private float waitTime = 2;
    
    public void Spalowany()
    {
        StartCoroutine(Spalowaniedsayhdash());

    }

    private IEnumerator Spalowaniedsayhdash()
    {
        yield return new WaitForSeconds(waitTime);
        blood.SetActive(true);
        Destroy(gameObject);
    }
}
