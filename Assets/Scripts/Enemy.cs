using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	private SpriteRenderer enemySprite;
	public float showTime;

	// Use this for initialization
	void Start () {
		enemySprite = gameObject.GetComponent<SpriteRenderer> ();
		enemySprite.enabled = false;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void showEnemy() {
		enemySprite.enabled = true;
		StartCoroutine (delay());
	}
	public void hideEnemy() {
		enemySprite.enabled = false;
	}
	IEnumerator delay() {
		yield return new WaitForSeconds (showTime);
		hideEnemy ();
	}
}
