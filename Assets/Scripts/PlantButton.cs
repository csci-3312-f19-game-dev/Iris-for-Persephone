using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantButton : MonoBehaviour
{
    [SerializeField]
    private GameObject plantPrefab;
    [SerializeField]
    private Sprite sprite;

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
