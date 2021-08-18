using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Resurs : MonoBehaviour
{
    public int WoodResurs;
    public int IronResurs;
    public int GoldResurs;
    public Text woodTextResurs;
    public Text ironTextResurs;
    public Text goldTextResurs;

    public Button BuildHome1;
    public Button BuildHome2;
    public Button BuildHome3;
    public Button BuildHome4;

    public GameObject[] targetResurs;
    public GameObject[] targetResursIron;
    public GameObject[] targetResursGold;
    public GameObject Home;

    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        woodTextResurs.text = WoodResurs.ToString();
        ironTextResurs.text = IronResurs.ToString();
        goldTextResurs.text = GoldResurs.ToString();

        BuildAndUpgrade();
    }

    public void BuildAndUpgrade()
    {
        
        //Build Home 1
        if (WoodResurs < 5)
            BuildHome1.interactable = false;
        else
            BuildHome1.interactable = true;
        //Build Home 2
        if (WoodResurs < 10)
            BuildHome2.interactable = false;
        else
            BuildHome2.interactable = true;
        //Build Home 3
        if (IronResurs < 7)
            BuildHome3.interactable = false;
        else
            BuildHome3.interactable = true;

        if (GoldResurs < 10)
            BuildHome4.interactable = false;
        else
            BuildHome4.interactable = true;
    }
   
}
