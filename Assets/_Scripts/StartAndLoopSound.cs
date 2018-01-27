using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StartAndLoopSound : MonoBehaviour {

	public AudioClip startClip, loopClip;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.loop = true;
		StartCoroutine (PlaySound ());
	}
	
	IEnumerator PlaySound(){
		audioSource.clip = startClip;
		audioSource.Play ();
		yield return new WaitForSeconds (audioSource.clip.length);
		audioSource.clip = loopClip;
		audioSource.Play ();
	}
}
