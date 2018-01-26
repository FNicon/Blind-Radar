using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Fish {

	void RamObject(Vector3 other) {
		dest = other;
		StartMoving (speed.runSpeed, GetRunDestination (other));
	}

	protected new void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<SubmarineControl> ()) {
			StopMoving ();
			if (Random.Range (0.0f, 100.0f) > 50.0f)
				RamObject (other.transform.position);
			else
				RunFromObject (other.transform.position);
		}
	}
}
