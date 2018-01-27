using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : Singleton<Score> {

	[System.Serializable]
	public class Scoring {
		public float distanceMultiplier = 1.0f;
		public float enemyDestroyed = 20.0f;
	}

	public Scoring scoring;
	public GameObject player;

	private Text scoreText;
	private Vector3 startPos;
	private float distScore, killScore;

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text> ();
		startPos = player.transform.position;
		distScore = killScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		distScore = Vector3.Distance (startPos, player.transform.position) * scoring.distanceMultiplier;
		UpdateScore ();
	}

	void UpdateScore () {
		scoreText.text = Mathf.Floor (distScore + killScore) + "";
	}

	public void KillEnemy () {
		killScore += scoring.enemyDestroyed;
	}
}
