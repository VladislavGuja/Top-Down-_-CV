using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fin : MonoBehaviour
{
    public GameObject g;
    void Start()
    {
       
        StartCoroutine(Guja());
    }
    
    IEnumerator Guja()
    {
        yield return new WaitForSeconds(4);
        g.SetActive(true);
    }
}
