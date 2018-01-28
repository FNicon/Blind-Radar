using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBehaviour : MonoBehaviour {
	public GameObject torpedo;
	public Transform torpedoSpawnPoint;
    public float shootDelay = 3f;
    public float shootWait = 10f;
    private Transform player;
    private bool firstTime = true;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(LockOn());
	}

    IEnumerator LockOn()
    {
        if (!firstTime)
        {
            yield return new WaitForSeconds(shootWait);
        }
        AlertManager.Instance.ShowAlert();
        yield return new WaitForSeconds(shootDelay);
        FireTorpedo();
        firstTime = false;
    }

	void FireTorpedo() {
		if (gameObject.transform.position.x > player.transform.position.x) {
			Instantiate (torpedo, torpedoSpawnPoint.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
		} else {
			Instantiate (torpedo, torpedoSpawnPoint.position, Quaternion.Euler (new Vector3 (0, 180,0)));
		}

        StartCoroutine(LockOn());
    }

    public void Dead()
    {
        GetComponentInParent<Troops>().TroopsDead();
        Destroy(this.gameObject);
    }
}
