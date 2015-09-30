using UnityEngine;
using System.Collections;

public class Canon : MonoBehaviour {
	public GameObject bullet;
	public Transform bulletSpawn;
	public GameObject barrel;
	GameObject[] enemies;
	GameObject closest;
	float count;
	
	void Start () {
	
	}

	void Update () {

		count += Time.deltaTime;
		if (count > 2 && findClosestEnemy() != null) {
			GameObject clone = Instantiate(bullet, bulletSpawn.transform.position, barrel.transform.rotation) as GameObject;
			clone.GetComponent<Rigidbody2D>().AddForce(barrel.transform.up * 1000);
			count = 0;

		}
		LookAtEnemy();
}

	GameObject findClosestEnemy(){
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		float dist = Mathf.Infinity;
		foreach (GameObject enem in enemies) {
			Vector2 diff = enem.transform.position - transform.position;
			float currentDist = diff.sqrMagnitude;
			if(currentDist < dist){
				closest = enem;
				dist = currentDist;
			}
		}
		return closest;
	}

	void LookAtEnemy(){
		var dir = transform.position - findClosestEnemy().transform.position;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		barrel.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
	}
}
