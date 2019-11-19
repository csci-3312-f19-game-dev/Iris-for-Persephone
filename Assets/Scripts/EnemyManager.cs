using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject enemyPrefab;

    [SerializeField]
    private int enemyScalingFactor;


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
