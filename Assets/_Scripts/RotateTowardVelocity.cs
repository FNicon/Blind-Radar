using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardVelocity : MonoBehaviour {

    public Rigidbody2D rb;
    private float angle;

	void Start () {
		
	}

	void Update () {
        Vector2 v = rb.velocity;
        if(v.x > 0f)
        {
            angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
