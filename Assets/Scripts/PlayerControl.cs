using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    private float movementX, movementY;
    public float speed = 8;
    public GameObject camera;
	// Use this for initialization
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

        /*
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.up * speed);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.down * speed / 2);
        }
        */
	}
}
