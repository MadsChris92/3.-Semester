using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
<<<<<<< HEAD
    //public GameObject enemy;
    //public FollowPath path;
=======
	public GameObject enemy;
    GameObject player;
    public float speed = 8;
>>>>>>> origin/master
    public float health = 100;
    public EnemyType enemyType;

    public enum EnemyType
    {
        basic, moderat, hard
    }

    // Use this for initialization
    void Start () {
<<<<<<< HEAD
=======
    
    bullet = GameObject.FindGameObjectWithTag ("Bullet");
        
>>>>>>> origin/master
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
        player = GameObject.FindGameObjectWithTag("Player");
        var pos = player.transform.position;
        var dir = pos - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        transform.Translate(Vector3.up * speed);
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
