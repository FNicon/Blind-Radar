using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBehaviour : MonoBehaviour {
	public float movementDelay;
	public float shootDelay;
	public int runProbability;
	private Rigidbody2D enemyBody;
	public float moveSpeed;
	private GameObject player;
	public GameObject torpedo;
	public Transform torpedoSpawnPoint;
	public string playerTag;

	void Start () {
		player = GameObject.FindGameObjectWithTag (playerTag);
		enemyBody = gameObject.GetComponent<Rigidbody2D> ();
		StartCoroutine (Movement());
		StartCoroutine (Shoot ());
	}

	void Update() {
		
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

	IEnumerator Shoot() {
		if (gameObject.transform.position.y == player.transform.position.y) {
			FireTorpedo ();
		}
		yield return new WaitForSeconds (shootDelay);
		StartCoroutine (Shoot ());
	}

	public void FireTorpedo() {
		Vector3 thisEulerAngles;
		thisEulerAngles = transform.eulerAngles;
		Instantiate (torpedo, torpedoSpawnPoint.position,Quaternion.Euler(new Vector3(thisEulerAngles.x,thisEulerAngles.y,thisEulerAngles.z*-1)));
	}
}
