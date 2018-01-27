using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troops : MonoBehaviour {

    public int numberOfTroops;
    public Spawner spawner;

	void Start () {
        spawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<Spawner>();
	}

	void Update () {
		
	}

    public void TroopsDead()
    {
        numberOfTroops--;
        if(numberOfTroops == 0)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        spawner.Spawn();
        Destroy(this.gameObject);
    }
}
