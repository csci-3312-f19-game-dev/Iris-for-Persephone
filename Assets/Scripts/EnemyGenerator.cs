using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefabs;

    public GameObject GetEnemy(string enemyName)
    {
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            if (enemyPrefabs[i].name == enemyName)
            {
                GameObject enemy = Instantiate(enemyPrefabs[i]);
                enemy.name = enemyName;
                return enemy;
            }
        }
        return null;
    }
}
