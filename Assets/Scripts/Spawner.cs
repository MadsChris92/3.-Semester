using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public Transform[] spawns;
    public GameObject[] enemies;
    int gameEnd = 0;
    public int spawnRate = 0;
    bool spawning = false;
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(gameEnd);
        gameEnd++;
        if (gameEnd < 3000)
        {
            int randomSpawn = Random.Range(0, 19);
            int randomEnem = Random.Range(0, 2);
            spawnRate++;
            if (spawnRate >= 40)
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
