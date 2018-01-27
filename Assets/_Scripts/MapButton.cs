using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButton : MonoBehaviour {
	public Canvas mainCanvas;
	public Canvas mapCanvas;
	// Use this for initialization
	void Start () {
		mapCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowMap() {
		mainCanvas.enabled = false;
		mapCanvas.enabled = true;
	}

	public void HideMap() {
		mainCanvas.enabled = true;
		mapCanvas.enabled = false;
	}
}
