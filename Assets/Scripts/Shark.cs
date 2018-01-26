using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Fish {

	[Range(0.0f, 100.0f)] public float chanceToRam = 50.0f;

	void RamObject(Vector3 other) {
		dest = other;
		StartMoving (speed.runSpeed, GetRunDestination (other));
	}

	protected new void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<SubmarineControl> ()) {
			StopMoving ();
			if (Random.Range (0.0f, 100.0f) <= chanceToRam)
				RamObject (other.transform.position);
			else
				RunFromObject (other.transform.position);
		}
	}
}
