using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopSpawner : MonoBehaviour {
	public GameObject[] troops;
	public int troopsFormation;

	// Use this for initialization
	void Start () {
		if (troopsFormation == 0) {
			SpawnTroop0 ();
		} else if (troopsFormation == 1) {
			SpawnTroop1 ();
		} else {
			SpawnTroop2 ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnTroop0() {
		int i;
		Vector3 spawnPosition;
		for (i = 0; i < troops.Length; i++) {
			spawnPosition = new Vector3 (transform.position.x + i * 4, transform.position.y);
			Instantiate (troops[i],spawnPosition,Quaternion.Euler(0,0,0));
		}
	}

	void SpawnTroop1() {
		int i;
		Vector3 spawnPosition;
		for (i = 0; i < troops.Length; i++) {
			spawnPosition = new Vector3 (transform.position.x, transform.position.y + i*4);
			Instantiate (troops[i],spawnPosition,Quaternion.Euler(0,0,0));
		}
	}

	void SpawnTroop2() {
		int i;
		Vector3 spawnPosition;
		for (i = 0; i < troops.Length; i++) {
			spawnPosition = new Vector3 (transform.position.x + i * 4, transform.position.y + i*4);
			Instantiate (troops[i],spawnPosition,Quaternion.Euler(0,0,0));
		}
	}

}
