using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cel : MonoBehaviour
{
    public Resurs resurs;
    public Rigidbody rb;
    public NavMeshAgent navMeshOm;

    public float distance;
  
    public int q;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        navMeshOm = GetComponent<NavMeshAgent>();
        resurs = GameObject.FindGameObjectWithTag("Resurs").GetComponent<Resurs>();

        for (int i = 0; i < resurs.targetResurs.Length; i++)
        {
            q = resurs.targetResurs.Length;
        }

        q = Random.Range(1, 14);

    }

    
    void Update()
    {
        if (q == 0)
        {
            q = Random.Range(1, 14);
        }

        distance = Vector3.Distance(transform.position,resurs.targetResurs[q].transform.position);
        navMeshOm.SetDestination(resurs.targetResurs[q].transform.position);
        if(distance <= 2.2)
        {
            CollectTheResurs();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
      if (resurs.targetResurs[q].tag == "Wood")
      {
            // StartCoroutine(ColectResurs());
            Debug.Log("da");
        }
     }
    
    public void CollectTheResurs()
    {
        q = 0;
        //yield return new WaitForSeconds(1);
        resurs.targetResurs[q].SetActive(false);
        resurs.WoodResurs += 1;
        //yield return new WaitForSeconds(0.1f);
        resurs.targetResurs[q].SetActive(true);
        resurs.BuildAndUpgrade();
        Debug.Log("+ lemn");
    }
    public IEnumerator ColectResurs()
    {
        q = 0;
        yield return new WaitForSeconds(1);
        resurs.targetResurs[q].SetActive(false);
        resurs.WoodResurs += 1;
        yield return new WaitForSeconds(0.1f);
        resurs.targetResurs[q].SetActive(true);
        resurs.BuildAndUpgrade();
        Debug.Log("+ lemn");
    }

}
