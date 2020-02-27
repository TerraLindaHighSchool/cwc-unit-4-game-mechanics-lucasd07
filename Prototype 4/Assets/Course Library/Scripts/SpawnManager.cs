using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private float spawnRange = 9;
    private float spawnPosX;
    private float spawnPosZ;

    private Vector3 randomPos;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPosX = Random.Range(-spawnRange, spawnRange);
        spawnPosZ = Random.Range(-spawnRange, spawnRange);
        randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        Instantiate(enemyPrefab, new Vector3(0, 0, 6), enemyPrefab.transform.rotation);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
