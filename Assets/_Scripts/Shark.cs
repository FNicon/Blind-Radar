using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Fish {

	[Range(0.0f, 100.0f)] public float chanceToRam = 50.0f;

	protected Vector3 GetRunOutsideDestination(Vector3 other) {
		float x = Random.Range(randomDistanceForRun.minX + 100, randomDistanceForRun.maxX + 100);
		float y = Random.Range(randomDistanceForRun.minY + 100, randomDistanceForRun.maxY + 100);

		if (other.x > transform.position.x)
			x *= -1;
		if (other.y > transform.position.y)
			y *= -1;

		topLeftScreen = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		topLeftScreen.x += margin;
		topLeftScreen.y -= margin;
		bottomLeftScreen = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		bottomLeftScreen.x -= margin;
		bottomLeftScreen.y += margin;

		Vector3 res = transform.position + new Vector3 (x, y, 0);
		return res;
	}


	void RamObject(Vector3 other) {
		dest = other;
		StartMovingInSine (speed.runSpeed, GetRunOutsideDestination (other), speed.runSpeed);
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
