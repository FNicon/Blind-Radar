using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBehaviour : MonoBehaviour {
	public GameObject torpedo;
	public Transform torpedoSpawnPoint;
    public float shootDelay = 3f;
    private Transform player;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(LockOn());
	}

	/*public void Detected() {
		transform.DOKill ();
		//DOTween.Clear ();
		Debug.Log ("Is this deteccted?");
		int probability = Random.Range (0, 10);
		if (probability <= runProbability) {
			Debug.Log ("Probability chance!");
			float newY = Random.Range (-3f, 3f);
			transform.DOLocalMoveY (newY, moveSpeed);
		}
	}

	IEnumerator Movement() {
		transform.DOKill ();
		//DOTween.Clear ();
		float oldY = gameObject.transform.position.y;
		float newY = player.transform.position.y;
		float deltaY = Mathf.Abs (oldY - newY);
		transform.DOMoveY (newY, deltaY * moveSpeed);
		yield return new WaitForSeconds (movementDelay);
		StartCoroutine (Movement ());
	}

	IEnumerator Shoot() {
		if (gameObject.transform.position.y > player.transform.position.y - 1 && gameObject.transform.position.y < player.transform.position.y + 1) {
            StartCoroutine(LockOn());
		}
		yield return new WaitForSeconds (shootDelay);
		StartCoroutine (Shoot ());
	}*/

    IEnumerator LockOn()
    {
        AlertManager.Instance.ShowAlert();
        yield return new WaitForSeconds(shootDelay);
        FireTorpedo();
    }

	public void FireTorpedo() {
		if (gameObject.transform.position.x > player.transform.position.x) {
			Instantiate (torpedo, torpedoSpawnPoint.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
		} else {
			Instantiate (torpedo, torpedoSpawnPoint.position, Quaternion.Euler (new Vector3 (0, 180,0)));
		}
	}
}
