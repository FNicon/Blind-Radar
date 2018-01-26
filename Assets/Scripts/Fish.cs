using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fish : MonoBehaviour {

	[System.Serializable]
	public class Speed {
		public float moveSpeed = 1.0f;
		public float runSpeed = 3.0f; 
		public float turnSpeed = 1.0f;
	}

	[System.Serializable]
	public class RandomDistanceForRun {
		public float minX = 5.0f;
		public float maxX = 10.0f;
		public float minY = 2.0f;
		public float maxY = 5.0f;
	}

	public Speed speed;
	public RandomDistanceForRun randomDistanceForRun;
	public float margin = 0.6f;
	protected Vector3 dest, topLeftScreen, bottomLeftScreen;

	// Use this for initialization
	void Start () {
		RandomDestination ();
		ApplyRotation ();
		StartMoving (speed.moveSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected void RandomDestination() {
		topLeftScreen = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		topLeftScreen.x += margin;
		topLeftScreen.y -= margin;
		bottomLeftScreen = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		bottomLeftScreen.x -= margin;
		bottomLeftScreen.y += margin;
		dest = new Vector3 (Random.Range (topLeftScreen.x, bottomLeftScreen.x), Random.Range (topLeftScreen.y, bottomLeftScreen.y), 0);
	}

	protected void StartMoving(float speed) {
		transform.DOMove (dest, speed).SetEase (Ease.InOutCubic).SetSpeedBased (true).OnComplete (ReachDestination);
	}

	protected void StartMoving(float speed, Vector3 destAfterReachDestination) {
		transform.DOMove (dest, speed).SetEase (Ease.InOutCubic).SetSpeedBased (true).OnComplete (() => ReachDestination(destAfterReachDestination));
	}

	protected void StopMoving() {
		transform.DOKill ();
	}

	protected void ApplyRotation() {
		if (dest.x > transform.position.x) {
			transform.DORotate (new Vector3 (0, -180, 0), speed.turnSpeed);
		} else {
			transform.DORotate (new Vector3 (0, 0, 0), speed.turnSpeed);
		}
	}

	protected void ReachDestination() {
		RandomDestination ();
		ApplyRotation ();
		StartMoving (speed.moveSpeed);
	}

	protected void ReachDestination(Vector3 destNext) {
		dest = destNext;
		ApplyRotation ();
		StartMoving (speed.moveSpeed);
	}

	protected Vector3 GetRunDestination(Vector3 other) {
		float x = Random.Range(randomDistanceForRun.minX, randomDistanceForRun.maxX);
		float y = Random.Range(randomDistanceForRun.minY, randomDistanceForRun.maxY);

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

		if (topLeftScreen.x > dest.x)
			dest.x = topLeftScreen.x;
		if (topLeftScreen.y < dest.y)
			dest.y = topLeftScreen.y;
		if (bottomLeftScreen.x < dest.x)
			dest.x = bottomLeftScreen.x;
		if (bottomLeftScreen.y > dest.y)
			dest.y = bottomLeftScreen.y;

		return res;
	}

	protected void RunFromObject(Vector3 other) {
		dest = GetRunDestination (other);
		ApplyRotation ();
		StartMoving (speed.runSpeed);
	}

	protected void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<SubmarineControl> ()) {
			StopMoving ();
			RunFromObject (other.transform.position);
		}
	}
}
