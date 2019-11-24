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
    //this is just a list of variables for reference in enemy combat and ui, instantiated in Start()
    private PlantAbility plant;
    
    
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
        plant = new PlantAbility(Name); //takes prefab to determine which plant abilities to use
        //can now refer to plant.health, plant.cost etc
        priceText.text = plant.cost + "$";
        //plant stat values go down here
        //
        //
        //
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
