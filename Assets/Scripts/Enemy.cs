using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    GameObject player;
    public GameObject blood;
    public float speed = 0.05f;
    public float health = 100;
    public EnemyType enemyType;
    public float decayTime = 5f;
    private float deadTime = 0f;
    private bool isDead = false;

    public enum EnemyType
    {
        basic, moderat, hard
    }

    // Use this for initialization
    void Start () {
    
        //bullet = GameObject.FindGameObjectWithTag ("Bullet");
        
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
        if (!isDead) {
            player = GameObject.FindGameObjectWithTag("Player");
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
        } else {
            deadTime += Time.deltaTime;
            if (deadTime > decayTime) {
                Destroy(gameObject);
            }
        }
 /*       var pos = player.transform.position;
        var dir = pos - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        transform.Translate(Vector3.up * speed);
        */
    }

    void OnCollisionEnter2D(Collision2D c){
		if (c.transform.tag == "Bullet") {
            health = health - 100;
            GameObject bloodclone = Instantiate(blood, transform.position, Quaternion.identity) as GameObject;
            if (health <= 0)
            {
                isDead = true;
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponentInChildren<Animator>().SetBool("isDead", true);

            }
		}
	}
}
