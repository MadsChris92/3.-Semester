using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    GameObject player;
    public GameObject blood;
    BulletPhysics bulPhys;
    GameObject bullet;
    public float speed = 0.05f;
    public float health = 100;
    public EnemyType enemyType;
    public bool decay = true;
    public float decayTime = 60f;
    private float deadTime = 0f;
    private bool dead = false;

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
       

        if (!dead) {
            player = GameObject.FindGameObjectWithTag("Player");
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
            if(player.transform.position.x > transform.position.x) {
                transform.localScale = new Vector3( 1, 1, 1);
            } else {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        } else {
            deadTime += Time.deltaTime;
            if (deadTime > decayTime && decay) {
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
       
        if (c.transform.tag == "Bullet" && !dead) {
            bulPhys = c.gameObject.GetComponent<BulletPhysics>();
            Debug.Log(bulPhys.getDamage());
            Destroy(c.gameObject);
            health = health - bulPhys.getDamage();
            GameObject bloodclone = Instantiate(blood, transform.position, Quaternion.identity) as GameObject;
            if (health <= 0)
            {
                dead = true;
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponentInChildren<Animator>().SetBool("isDead", true);
                gameObject.tag = "Corpse";
                GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Corpses";

            }
		}
	}
}
