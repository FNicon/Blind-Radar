using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Radar : MonoBehaviour {
	public CircleCollider2D radarCollider;
	public float speed;
	public float maxRadius;
	public string enemyTag;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ResetRadar ();
	}

	public void UsingRadar(){
		ResetRadar ();
		DOTween.To(() => radarCollider.radius, x => radarCollider.radius = x, maxRadius, speed);
	}
	public void ResetRadar() {
		if (radarCollider.radius >= maxRadius) {
			radarCollider.radius = 0;
		}
	}
	public bool isDetectEnemy() {
		return (true);
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag (enemyTag)) {
			other.GetComponent<Enemy> ().showEnemy ();
		}
	}
}
