using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBehaviour : MonoBehaviour {
	public float movementDelay;
	public int runProbability;
	private Rigidbody2D enemyBody;
	public float moveSpeed;
	public Transform player;
	public GameObject torpedo;
	public Transform torpedoSpawnPoint;

	void Start () {
		enemyBody = gameObject.GetComponent<Rigidbody2D> ();
		StartCoroutine (Movement());
	}

	void Update() {
		if (gameObject.transform.position.y == player.transform.position.y) {
			FireTorpedo ();
		}
	}

	public void Detected() {
		DOTween.Clear ();
		Debug.Log ("Is this deteccted?");
		int probability = Random.Range (0, 10);
		if (probability <= runProbability) {
			Debug.Log ("Probability chance!");
			float newY = Random.Range (-3f, 3f);
			transform.DOLocalMoveY (newY, moveSpeed);
		}
	}

	IEnumerator Movement() {
		DOTween.Clear ();
		float oldY = gameObject.transform.position.y;
		float newY = player.transform.position.y;
		float deltaY = Mathf.Abs (oldY - newY);
		transform.DOMoveY (newY, deltaY * moveSpeed);
		yield return new WaitForSeconds (movementDelay);
		StartCoroutine (Movement ());
	}

	public void FireTorpedo() {
		//Quaternion torpedoRotation;
		//torpedoRotation.Set (0, 0, 0, 0);
		//torpedoRotation.SetFromToRotation (gameObject.transform.position, player.transform.position);
		Instantiate (torpedo, torpedoSpawnPoint);
	}
}
