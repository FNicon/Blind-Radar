using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void BackToMenu()
    {
        AudioSource aSource = (AudioSource)FindObjectOfType(typeof(AudioSource));
        Destroy(aSource.gameObject);
        Application.LoadLevel("Title Scene");
    }
}
