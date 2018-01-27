﻿using UnityEngine;
using DG.Tweening;

public class Radar : MonoBehaviour {
	public CircleCollider2D radarCollider;
	public float speed;
	public float maxRadius;
	public string enemyTag;

	void Start () {
		
	}
	
	void Update () {
		ResetRadar ();
	}

	public void UsingRadar(){
		ResetRadar ();
		GetComponent<AudioSource> ().Play ();
		DOTween.To(() => radarCollider.radius, x => radarCollider.radius = x, maxRadius, speed);
	}

	public void ResetRadar() {
		if (radarCollider.radius >= maxRadius) {
			radarCollider.radius = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(enemyTag))
        {
            RadarListener enemyRadarListener = other.GetComponent<RadarListener>();
            if (enemyRadarListener)
                enemyRadarListener.ShowEnemy();
            else
                Debug.Log("Enemy gak ada radar listenernya");
			/*EnemyBehaviour enemyBehave = other.GetComponent<EnemyBehaviour> ();
			if (enemyBehave) {
				enemyBehave.Detected ();
			}*/
        }
	}
}