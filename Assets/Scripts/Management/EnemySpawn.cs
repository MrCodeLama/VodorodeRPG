using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    public void createEnemies(HashSet<Vector2Int> floor)
    {
        int maxNumberOfEnemies = Random.Range(5,20);
        int numberOfEnemies = 0;
        foreach (var position in floor)
        {
            if (numberOfEnemies <= maxNumberOfEnemies)
            {
                if (Random.Range(0, 100) <= 10)
                {
                    Instantiate(EnemyPrefab, new Vector3(position.x+0.5f, position.y), Quaternion.identity);
                    numberOfEnemies++;
                }
            }
        }
    }

    public void DeleteAll()
    {
        GameObject[] toDelete = GameObject.FindGameObjectsWithTag("enemy");
        foreach(GameObject item in toDelete)
            Destroy(item);  
    }
}
