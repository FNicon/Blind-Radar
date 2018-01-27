using System.Collections;
using UnityEngine;

public class RadarListener : MonoBehaviour {
	public SpriteRenderer renderer;
	public float showTime;

	void Start () {
        if (!renderer)
            Debug.LogError("Tidak ada renderer");
        renderer.enabled = false;	
	}
	
	void Update () {
		
	}
	public void ShowEnemy() {
        renderer.enabled = true;
		StartCoroutine (Delay());
	}
	public void HideEnemy() {
        renderer.enabled = false;
	}
	IEnumerator Delay() {
		yield return new WaitForSeconds (showTime);
        HideEnemy();
	}
}
