using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;
	public GameObject positionParent;

	private GameObject startPositionParent, dragPositionParent;

	void Start() {
		startPositionParent = positionParent;
		transform.position = positionParent.transform.position;
	}

	void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag(){
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
	}

	void OnMouseUp(){
		if (dragPositionParent != null)
			startPositionParent = dragPositionParent;
		transform.position = startPositionParent.transform.position;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.tag == "Position")
			dragPositionParent = collider.gameObject;
	}

	void OnTriggerExit2D(Collider2D collider) {
		if(collider.tag == "Position")
			dragPositionParent = null;
	}
}
