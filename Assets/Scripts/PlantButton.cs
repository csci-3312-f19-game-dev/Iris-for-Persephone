using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantButton : MonoBehaviour
{
    [SerializeField]
    private GameObject plantPrefab;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private int price;
    public int Price { get => price; }
    [SerializeField]
    private Text priceText;
   
    
    //get name of prefab object to tag it w/ its stats
    public string Name
    {
        get
        {
            return plantPrefab.name;
        }
    }
    


    private void Start()
    {
        priceText.text = Price + "$";
        
    }

    public GameObject PlantPrefab
    {
        get
        {
            return plantPrefab;
        }
    }

    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }

}
