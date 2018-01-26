using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public float spawnTime;
	public float spawnDelay;
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;
	public GameObject[] spawnThings;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnDelay, spawnTime);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Spawn() {
		int spawnIndex = Random.Range (0, spawnThings.Length);
		float x = Random.Range (xMin, xMax);
		float y = Random.Range (yMin, yMax);
		Vector3 spawnPosition = new Vector3(x,y);
		Instantiate (spawnThings [spawnIndex],spawnPosition, transform.rotation);
	}
}
