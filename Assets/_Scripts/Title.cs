using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;

public class Title : MonoBehaviour {
	public VideoPlayer videoTitle;
	public long framePause;
	public long frameEnd;
	public DOTweenAnimation titleText;
	public bool isFinished = false;
	public DOTweenAnimation fader;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (videoTitle.frame == framePause && isFinished == false) {
			videoTitle.Pause();
			StartShow();
			isFinished = true;
			//Debug.Log("OY");
			//titleText.GetComponent<DOTween>()
		} else if (videoTitle.frame == frameEnd) {

		}
	}
	void StartShow() {
		titleText.DOPlay();
	}
	public void StartGame() {
		fader.DOPlay();
		videoTitle.frame = 148;
		videoTitle.Play();
	}
}
