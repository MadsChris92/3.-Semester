using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    private float movementX, movementY;
    public float speed = 0.05f;
    public GameObject bullet;
    bool isShooting = false;
    public GameObject camera;
    int counter = 0;
    public Transform bulletSpawn;
    bool isMoving;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //        camera.transform.position.y = 
        //        Vector3 pPos = transform.position;
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        Vector3 posC = Camera.main.WorldToScreenPoint(transform.position);
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            transform.Translate(Vector3.up * speed);

        



        if (Input.GetButton("Fire1"))
        {
            counter++;
            if(counter >= 10)
            {
                isShooting = true;
                counter = 0;
            }
            if (isShooting)
            {
                GameObject clone = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.rotation) as GameObject;
                clone.GetComponent<Rigidbody2D>().AddForce(clone.transform.up * 1000);
                isShooting = false;
            }
        }
	}
}
