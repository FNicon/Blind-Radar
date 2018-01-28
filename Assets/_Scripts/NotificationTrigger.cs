using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationTrigger : Singleton<NotificationTrigger> {
	public Notification notification;
	public NotificationManager notificationManager;

	/*void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			TriggerNotification ();
		}
	}*/

	public void TriggerNotification (int notificationIndex) {
		notificationManager.Startnotification(notification, notificationIndex);
	}
}
