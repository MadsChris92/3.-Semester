using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject enemy;
    public float health = 100;
    public FollowPath path;
	GameObject bullet;
    public EnemyType enemyType;

    public enum EnemyType
    {
        basic, moderat, hard
    }

    // Use this for initialization
    void Start () {
        path = path.GetComponent<FollowPath>();
    bullet = GameObject.FindGameObjectWithTag ("Bullet");
        if (enemyType == EnemyType.basic)
        {
            health = health * 2;
            path.Speed = 1;
        }
        if(enemyType == EnemyType.moderat)
        {
            health = health * 3;
            path.Speed = 10;
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
