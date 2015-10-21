using UnityEngine;
using System.Collections;

public class Canon : MonoBehaviour {
	public GameObject bullet;
	public Transform bulletSpawn;
	public GameObject barrel;
    public float fireDelay = 2.0f;
    public float range = 50;
	GameObject[] enemies;
	float count;
	
	void Start () {
	
	}

	void Update () {

		count += Time.deltaTime;
        LookAtEnemy();
        if (count > fireDelay && findClosestEnemy() != null) {
			GameObject clone = Instantiate(bullet, bulletSpawn.transform.position, barrel.transform.rotation) as GameObject;
            clone.GetComponent<Rigidbody2D>().AddForce(barrel.transform.up * 1000);
			count = 0;
            barrel.GetComponent<Animator>().SetTrigger("Fire");
		}
}

	GameObject findClosestEnemy(){
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		float dist = range;
        GameObject closest = null;
        foreach (GameObject enemy in enemies) {
			Vector2 diff = enemy.transform.position - transform.position;
			float currentDist = diff.sqrMagnitude;
			if(currentDist < dist){
				closest = enemy;
				dist = currentDist;
			}
		}
		return closest;
	}

	void LookAtEnemy(){
        var enemy = findClosestEnemy();
        if (enemy != null) {
            var dir = transform.position - enemy.transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            barrel.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        }
	}
}
