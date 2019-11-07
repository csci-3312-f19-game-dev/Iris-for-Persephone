using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject enemyPrefab;
    public float interpolationPeriod = 3.0f;

    private float actionTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        actionTime += Time.deltaTime;

        if (actionTime >= interpolationPeriod)
        {
            actionTime = 0.0f;

            Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
