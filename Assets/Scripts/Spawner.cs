using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public Transform[] spawns;
    public GameObject[] enemies;
    int gameEnd = 0;
    int spawnRate = 0;
    public int SpawnRate = 0;
    bool spawning = false;
    void Start()
    {
        
    }

    void Update()
    {
        gameEnd++;
        if (gameEnd < 2000)
        {
            int randomSpawn = Random.Range(0, spawns.Length);
            int randomEnem = Random.Range(0, enemies.Length);
            spawnRate++;
            if (spawnRate >= SpawnRate)
            {
                spawning = true;
                spawnRate = 0;
            }
            if (spawning)
            {
                GameObject enemy = Instantiate(enemies[randomEnem], spawns[randomSpawn].transform.position, Quaternion.identity) as GameObject;
                spawning = false;
            }
        }
        else { }
    }
}
