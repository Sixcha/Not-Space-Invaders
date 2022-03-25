using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    // Create spawn pattern delegates
    delegate void SpawnPatternMethod();

    // To put enemies in prefab array
    public GameObject[] enemyPrefabs = new GameObject[3];

    void CreateList()
    {
        // Collect delegates in a List
        List<SpawnPatternMethod> spawnEnemy = new List<SpawnPatternMethod>();
        spawnEnemy.Add(StraightEnemyLine);
        spawnEnemy.Add(TriangleEnemyLine);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StraightEnemyLine()
    {
        // Instantiate enemies in a straight line

    }

    void TriangleEnemyLine()
    {

    }
}
