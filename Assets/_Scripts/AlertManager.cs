using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertManager : Singleton<AlertManager> {

    public GameObject alertUI;
    public float duration = 3f;

    private void Awake()
    {
        instance = this;
    }

    void Start () {
		
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowAlert();
        }
	}

    public void ShowAlert()
    {
        alertUI.SetActive(true);
        StartCoroutine(HideDelay());
    }

    IEnumerator HideDelay()
    {
        yield return new WaitForSeconds(duration);
        alertUI.SetActive(false);
    }
}
