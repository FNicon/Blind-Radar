using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour {
	public Text notificationText;

	//private Animator notificationAnimator;
	private Queue<string> sentences;
	private float durationPerNotification;

	// Use this for initialization
	void Start () {
		//notificationAnimator = GetComponent<Animator> ();
		sentences = new Queue<string>();
	}

	public void Startnotification (Notification inputnotification, int notifIndex) {
		//notificationAnimator.SetBool("isStartNotification", true);
		durationPerNotification = inputnotification.notificationDuration;
		sentences.Clear();
		string sentence = inputnotification.notif[notifIndex];
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
		yield return new WaitForSeconds (durationPerNotification);
		DisplayNextnotification ();
	}

	void Endnotification() {
		sentences.Clear ();
		//notificationAnimator.SetBool("isStartNotification", false);
	}
}
