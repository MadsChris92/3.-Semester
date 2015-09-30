using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject enemy;
	GameObject bullet;
	// Use this for initialization
	void Start () {
		bullet = GameObject.FindGameObjectWithTag ("Bullet");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.transform.tag == "Bullet") {
			Destroy(gameObject);
		}
	}
}
