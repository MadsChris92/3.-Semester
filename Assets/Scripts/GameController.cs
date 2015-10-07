using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject[] enemies = new GameObject[2];
	public int EnemyID= 1;
	float timePassed;
	public Spawner spawner;
	public p[] paths = new p[8];
	public GameObject tower;
    bool tower1Picked = false, spawnMob1 = false;
    int counter = 0;

	void Start () {
		spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && tower1Picked) {
			Vector3 pos1 = Input.mousePosition;
			pos1.z = 10;
			Vector3 pos = Camera.main.ScreenToWorldPoint(pos1);
			GameObject clone = Instantiate(tower, pos, transform.rotation)as GameObject;
            tower1Picked = false;
		}
		timePassed += Time.deltaTime;
/*		if (timePassed > 0f && timePassed < 5f) {
			spawner.spawnOne(paths[0],enemies[0], 4,1);
            return;
		}
		spawner.counter = 0;
        */
        if(spawnMob1 == true)
        {
            spawner.spawnOne(paths[0], enemies[0], 2, 1);
            spawnMob1 = false;
        }
        spawner.counter = 0;
    }

    public void spawnMob()
    {
        spawnMob1 = true;
    }

    public void tower1()
    {
        tower1Picked = true;
    }
}
