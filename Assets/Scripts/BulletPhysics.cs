using UnityEngine;
using System.Collections;

public class BulletPhysics : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D c){
		if (c.transform.tag == "Enemy") {
			Destroy(gameObject);
		}
	}
}
