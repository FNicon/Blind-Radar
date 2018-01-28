using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour {
	public bool isAllowControl = false;
	public GameObject startScreen;
	public GameObject endingScreen;
	public GameObject creditScreen;
	public GameObject titleScreen;
	
	void Start () {
		isAllowControl = false;
		titleScreen.SetActive(true);
		startScreen.SetActive(false);
		endingScreen.SetActive(false);
		creditScreen.SetActive(false);
	}

	public void StartGame() {
		isAllowControl = false;
		titleScreen.SetActive(false);
		startScreen.SetActive(true);
		endingScreen.SetActive(false);
		creditScreen.SetActive(false);
	}

	public void BeginGame() {
		isAllowControl = true;
		titleScreen.SetActive(false);
		startScreen.SetActive(false);
		endingScreen.SetActive(false);
		creditScreen.SetActive(false);
	}

	public void EndGame() {
		isAllowControl = false;
		titleScreen.SetActive(false);
		startScreen.SetActive(false);
		endingScreen.SetActive(true);
		creditScreen.SetActive(false);
	}

	public void CreditGame() {
		isAllowControl = false;
		titleScreen.SetActive(false);
		startScreen.SetActive(false);
		endingScreen.SetActive(false);
		creditScreen.SetActive(true);
	}

	public void TitleGame() {
		isAllowControl = false;
		titleScreen.SetActive(true);
		startScreen.SetActive(false);
		endingScreen.SetActive(false);
		creditScreen.SetActive(false);
	}
}
