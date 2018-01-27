using UnityEngine;

public class Spawner : MonoBehaviour {
	public float spawnTime;
	public float spawnDelay;
	public float yMin;
	public float yMax;
	public GameObject[] spawnThings;

	void Start () {
		InvokeRepeating ("Spawn", spawnDelay, spawnTime);	
	}
	
	void Update () {
		
	}
	void Spawn() {
		int spawnIndex = Random.Range(0, spawnThings.Length);
		float y = Random.Range(yMin, yMax);
		Vector3 spawnPosition = new Vector3(transform.position.x,y);
		Instantiate (spawnThings [spawnIndex], spawnPosition, transform.rotation);
	}
}
