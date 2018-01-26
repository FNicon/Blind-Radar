using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	public float movementDelay;
	public int runProbability;
	private Rigidbody2D enemyBody;
	public float runSpeed;
	public Transform player;
	private bool isRun;
	private bool isReform;
	private int movement;

	void Start () {
		enemyBody = gameObject.GetComponent<Rigidbody2D> ();
		isRun = false;
		StartCoroutine (Movement());
	}

	void Update() {
		if (isReform) {
			Reformation ();
		} else {
			Stop ();
		}
	}

	IEnumerator Movement() {
		yield return new WaitForSeconds (movementDelay);
		if (!isRun) {
			isReform = true;
		}
		StartCoroutine (Movement ());
	}

	public void RandomRun() {
		int randomValue;
		randomValue = Random.Range (0, 10);
		if (randomValue <= runProbability) {
			isRun = true;
			Run ();
		}
	}

	void Run() {
		movement = Random.Range (-1, 1);
		enemyBody.velocity = new Vector2 (enemyBody.velocity.x, (enemyBody.velocity.y + runSpeed) * movement);
		isRun = false;
	}

	void Reformation() {
		float enemyY;
		float playerY;
		playerY = player.transform.position.y;
		enemyY = this.transform.position.y;
		if (playerY > enemyY) {
			movement = 1;
		} else {
			movement = -1;
		}
		enemyBody.velocity = new Vector2 (enemyBody.velocity.x, (enemyBody.velocity.y + runSpeed) * movement);
		isReform = false;
	}

	void Stop() {
		enemyBody.velocity = new Vector2 (0,0);
	}
}
