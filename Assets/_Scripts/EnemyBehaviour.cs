using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBehaviour : MonoBehaviour {
	public GameObject torpedo;
	public Transform torpedoSpawnPoint;
    public float shootDelay = 3f;
    private Transform player;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(LockOn());
	}

    IEnumerator LockOn()
    {
        AlertManager.Instance.ShowAlert();
        yield return new WaitForSeconds(shootDelay);
        FireTorpedo();
    }

	public void FireTorpedo() {
		if (gameObject.transform.position.x > player.transform.position.x) {
			Instantiate (torpedo, torpedoSpawnPoint.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
		} else {
			Instantiate (torpedo, torpedoSpawnPoint.position, Quaternion.Euler (new Vector3 (0, 180,0)));
		}
	}

    public void Dead()
    {
        GetComponentInParent<Troops>().TroopsDead();
        Destroy(this.gameObject);
    }
}
