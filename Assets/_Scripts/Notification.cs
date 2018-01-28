using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Notification {

	[System.Serializable]
	public class SingleNotification {
		[TextArea(3,10)] public string notif;
		public Sprite charImage;
	}

	public SingleNotification[] notifications;
	public float notificationDuration;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
