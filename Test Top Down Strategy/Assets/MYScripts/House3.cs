using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House3 : MonoBehaviour
{
    public Resurs resurs;
    public Button UpLvl;
    [SerializeField] GameObject Build;
    void Start()
    {
        StartCoroutine(SpawnCel());
        resurs = GameObject.FindGameObjectWithTag("Resurs").GetComponent<Resurs>();
    }

    void LateUpdate()
    {
        if (resurs.IronResurs < 3)
            UpLvl.interactable = false;
        else
            UpLvl.interactable = true;
    }
    IEnumerator SpawnCel()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(Build, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
    public void UpGradeHome()
    {
        Instantiate(Build, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        resurs.IronResurs -= 3;
    }
}
