using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : Singleton<BossManager> {

    private void Awake()
    {
        instance = this;
    }

    void Start () {
		
	}

	void Update () {
		
	}

    public void SpawnBoss()
    {
        Debug.Log("Boss spawned");
    }
}
