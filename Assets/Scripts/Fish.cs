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

    void Start () {
		RandomDestination ();
		ApplyRotation ();
		StartMovingInOutCubic (speed.moveSpeed);
	}
	
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

	protected void StartMovingInOutCubic(float speed) {
		transform.DOMove (dest, speed).SetEase (Ease.InOutCubic).SetSpeedBased (true).OnComplete (() => ReachDestinationInOutCubic(this.speed.moveSpeed));
	}

	protected void StartMovingInSine(float speed, Vector3 destAfterReachDestination, float nextSpeed) {
		transform.DOMove (dest, speed).SetEase (Ease.InSine).SetSpeedBased (true).OnComplete (() => ReachDestinationOutSine(nextSpeed, destAfterReachDestination));
	}

	protected void StartMovingOutSine(float speed) {
		transform.DOMove (dest, speed).SetEase (Ease.OutSine).SetSpeedBased (true).OnComplete (() => ReachDestinationInOutCubic(this.speed.moveSpeed));
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

	protected void ReachDestinationInOutCubic(float nextSpeed) {
		RandomDestination ();
		ApplyRotation ();
		StartMovingInOutCubic (nextSpeed);
	}

	protected void ReachDestinationInSine(float nextSpeed, Vector3 destNext) {
		dest = destNext;
		ApplyRotation ();
		StartMovingInSine (nextSpeed, destNext, this.speed.runSpeed);
	}

	protected void ReachDestinationOutSine(float nextSpeed, Vector3 destNext) {
		dest = destNext;
		ApplyRotation ();
		StartMovingOutSine (nextSpeed);
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
		StartMovingOutSine (speed.runSpeed);
	}

	protected void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Torpedo")) {
			StopMoving ();
			RunFromObject (other.transform.position);
		}
	}
}
