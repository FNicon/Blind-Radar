using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour {

	public float incSpeed = 1.0f, maxSpeed = 10.0f;
	private Rigidbody2D rigidBody;
	private GameObject particle;

	// Use this for initialization
	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
		particle = gameObject.transform.GetChild (0).gameObject;

		particle.transform.localEulerAngles = new Vector3 ((transform.eulerAngles.z * -1 - 90), -90, -90);
	}

	// Update is called once per frame
	void Update () {
		//if (rigidBody.velocity.x < maxSpeed)
		//	rigidBody.velocity += new Vector2 (incSpeed, 0);
		if (rigidBody.velocity.magnitude < maxSpeed)
			rigidBody.AddForce (transform.right * -incSpeed * 50);
	}
}
