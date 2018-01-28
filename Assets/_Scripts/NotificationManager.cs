using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NotificationManager : MonoBehaviour {
	public GameObject notificationBox;
	public Text notificationText;
	public Image notificationChar;

	//private Animator notificationAnimator;
	private Queue<string> sentences;
	private float durationPerNotification;

	private const float notificationShowHideDiff = 548;

	// Use this for initialization
	void Start () {
		//notificationAnimator = GetComponent<Animator> ();
		sentences = new Queue<string>();
	}

	public void Startnotification (Notification inputnotification, int notifIndex) {
		//notificationAnimator.SetBool("isStartNotification", true);
		durationPerNotification = inputnotification.notificationDuration;
		sentences.Clear();
		notificationChar.sprite = inputnotification.notifications [notifIndex].charImage;
		string sentence = inputnotification.notifications [notifIndex].notif;
		sentences.Enqueue(sentence);
		/*foreach (string sentence in inputnotification.notif[NotifIndex]) {
			sentences.Enqueue(sentence);
		}*/
		DisplayNextnotification();
	}

	public void DisplayNextnotification () {
		if (sentences.Count == 0) {
			Endnotification();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		notificationText.text = sentence;
		//StartCoroutine(TypeSentence(sentence));
		StartCoroutine(duration());
	}

	/*IEnumerator TypeSentence (string sentence)
	{
		notificationText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			notificationText.text += letter;
			yield return null;
		}
	}*/

	IEnumerator duration () {
		yield return ShowNotification ();
		yield return new WaitForSeconds (durationPerNotification);
		yield return HideNotification ();
		DisplayNextnotification ();
	}

	IEnumerator ShowNotification () {
		notificationBox.transform.DOLocalMoveX (680, 1).SetEase (Ease.InBack);
		yield return new WaitForSeconds (1);
	}

	IEnumerator HideNotification () {
		notificationBox.transform.DOLocalMoveX (1500, 1).SetEase (Ease.OutBack);
		yield return new WaitForSeconds (1);
	}

	void Endnotification() {
		sentences.Clear ();
		//notificationAnimator.SetBool("isStartNotification", false);
	}
}
