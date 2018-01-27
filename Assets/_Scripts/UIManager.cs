using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void Show(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void Hide(GameObject panel)
    {
        panel.SetActive(false);
    }
}
