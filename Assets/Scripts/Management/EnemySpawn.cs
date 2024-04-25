using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> EnemyPrefab;
    [SerializeField] private GameObject Enemies;
    public void createEnemies(HashSet<Vector2Int> floor)
    {
        int maxNumberOfEnemies = Random.Range(5,10);
        int numberOfEnemies = 0;
        foreach (var position in floor)
        {
            if (numberOfEnemies <= maxNumberOfEnemies)
            {
                if (Random.Range(0, 100) <= 10)
                {
                    var NewEnemy = Instantiate(EnemyPrefab[Random.Range(0, EnemyPrefab.Count)], new Vector3(position.x+0.5f, position.y), Quaternion.identity);
                    NewEnemy.transform.parent = Enemies.transform;
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
