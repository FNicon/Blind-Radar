using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fish : MonoBehaviour {

	public float moveSpeed = 1.0f, turnSpeed = 1.0f, margin = 0.6f;
	private Vector3 dest, topLeftScreen, bottomLeftScreen;

	// Use this for initialization
	void Start () {
		RandomDestination ();
		ApplyRotation ();
		StartMoving ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void RandomDestination() {
		topLeftScreen = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		topLeftScreen.x += margin;
		topLeftScreen.y -= margin;
		bottomLeftScreen = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		bottomLeftScreen.x -= margin;
		bottomLeftScreen.y += margin;
		dest = new Vector3 (Random.Range (topLeftScreen.x, bottomLeftScreen.x), Random.Range (topLeftScreen.y, bottomLeftScreen.y), 0);
	}

	void StartMoving() {
		transform.DOMove (dest, moveSpeed).SetEase (Ease.InOutCubic).SetSpeedBased (true).OnComplete (ReachDestination);
	}

	void ApplyRotation() {
		if (dest.x > transform.position.x) {
			transform.DORotate (new Vector3 (0, -180, 0), turnSpeed);
		} else {
			transform.DORotate (new Vector3 (0, 0, 0), turnSpeed);
		}
	}

	void ReachDestination() {
		RandomDestination ();
		ApplyRotation ();
		StartMoving ();
	}
}
