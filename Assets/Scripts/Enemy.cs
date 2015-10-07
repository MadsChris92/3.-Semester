using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    //public GameObject enemy;
    //public FollowPath path;
    public float health = 100;
    public EnemyType enemyType;

    public enum EnemyType
    {
        basic, moderat, hard
    }

    // Use this for initialization
    void Start () {
        if (enemyType == EnemyType.basic)
        {
            health = health * 2;
        }
        if(enemyType == EnemyType.moderat)
        {
            health = health * 3;
        }
        if (enemyType == EnemyType.hard) {
            health = health * 5;
        }
    }
	
	// Update is called once per frame
	void Update () {
	   
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.transform.tag == "Bullet") {
            health = health - 100;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
		}
	}
}
