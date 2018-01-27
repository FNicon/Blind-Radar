using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEasterEggs : MonoBehaviour {
	public SpriteRenderer horst;
	public float waitTime;

	// Use this for initialization
	void Start () {
		horst.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator DeepDown() {
		yield return new WaitForSeconds (waitTime);
		horst.enabled = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			StartCoroutine (DeepDown ());
		}
	}
}
