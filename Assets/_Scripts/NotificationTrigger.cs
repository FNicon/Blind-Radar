using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationTrigger : MonoBehaviour {
	public Notification notification;
	public NotificationManager notificationScript;

	/*void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			TriggerNotification ();
		}
	}*/

	public void TriggerNotification (int notificationIndex) {
		notificationScript.Startnotification(notification, notificationIndex);
	}
}
