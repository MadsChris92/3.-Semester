using UnityEngine;
using System.Collections;

public class VisionCone : MonoBehaviour {
    public float rangeCone = 5;
    public float rangeClose = 1;
    public float angle = 80;
    public int points = 5;
	
    public bool canSee(Vector3 point) {
        if ((point - transform.position).magnitude <= rangeClose) return true;
        if ((point - transform.position).magnitude <= rangeCone) {
            if(Vector3.Angle((point - transform.position), transform.up) <= angle/2) return true;
        }
        return false;
    }

    public void OnDrawGizmos() {
        if (points < 2) {
            return;
        }
        Vector2 vec = Quaternion.Euler(0, 0, - angle / 2) * transform.up * rangeCone;
        Vector2[] p = new Vector2[points];
        for (int i = 0; i < points; i++) {
            p[i] = new Vector2(transform.position.x + vec.x, transform.position.y + vec.y);
            vec = Quaternion.Euler(0, 0, angle / (points - 1)) * vec;
        }
        Gizmos.DrawLine(transform.position, p[0]);
        for (int i = 1; i < points; i++) {
            Gizmos.DrawLine(p[i - 1], p[i]);
        }
        Gizmos.DrawLine(p[points-1], transform.position);
        Gizmos.DrawWireSphere(transform.position, rangeClose);
    }
}
