using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour {

	public float incSpeed = 1.0f, maxSpeed = 10.0f;
	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(rigidBody.velocity.x < maxSpeed) rigidBody.velocity += new Vector2(incSpeed, 0);
	}
}
