using UnityEngine;
using System.Collections;

public class BulletPhysics : MonoBehaviour {

    public BulletType bulletType;
    float damage;

    public enum BulletType
    {
        standard, laser
    }
	void Start () {
        if (bulletType == BulletType.standard)
        {
            damage = 100;
        }
    }
	
	// Update is called once per frame
	void Update () {

    
    }

    public float getDamage()
    {
        return damage;
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.transform.tag == "Level") {
            Destroy(gameObject);
        }
    }
}
