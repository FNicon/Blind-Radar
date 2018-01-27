using System.Collections;
using UnityEngine;

public class RadarListener : MonoBehaviour {
	public SpriteRenderer radarRenderer;
	public SpriteRenderer enemyRenderer;
	public float showTime;

	void Start () {
        if (!radarRenderer || !enemyRenderer)
            Debug.LogError("Tidak ada renderer");
        radarRenderer.enabled = false;
		enemyRenderer.enabled = false;
	}
	
	void Update () {
		
	}
	public void ShowEnemy() {
        radarRenderer.enabled = true;
		enemyRenderer.enabled = true;
		StartCoroutine (Delay());
	}
	public void HideEnemy() {
        radarRenderer.enabled = false;
		enemyRenderer.enabled = false;
	}
	IEnumerator Delay() {
		yield return new WaitForSeconds (showTime);
        HideEnemy();
	}
}
