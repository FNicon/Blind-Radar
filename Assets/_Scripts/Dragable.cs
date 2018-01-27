using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	[HideInInspector]
	public Transform parentReturn = null;
	[HideInInspector]
	public Transform parentTemp = null;

	private GameObject placeHolder = null;

	private void Start() {
		//parentTemp = this.transform.parent;
	}

	public void OnBeginDrag(PointerEventData pointerData) {
		placeHolder = new GameObject ();
		placeHolder.transform.SetParent (this.transform.parent);
		LayoutElement element = placeHolder.AddComponent<LayoutElement> ();
		element.preferredWidth = this.GetComponent<LayoutElement> ().preferredWidth;
		element.preferredHeight = this.GetComponent<LayoutElement> ().preferredHeight;
		element.flexibleWidth = 0;
		element.flexibleHeight = 0;

		placeHolder.transform.SetSiblingIndex (this.transform.GetSiblingIndex ());

		parentReturn = this.transform.parent;
		parentTemp = parentReturn;

		this.transform.SetParent (this.transform.parent);

		this.GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData pointerData) {
		this.transform.position = pointerData.position;
		if (placeHolder.transform.parent != parentTemp) {
			placeHolder.transform.SetParent (parentTemp);
		}
		int newSiblingIndex = parentTemp.childCount;
		for (int i = 0; i < parentTemp.childCount; i++) {
			if (this.transform.position.x < parentTemp.GetChild (i).position.x) {
				newSiblingIndex = i;
				if (placeHolder.transform.GetSiblingIndex () < newSiblingIndex) {
					newSiblingIndex = newSiblingIndex - 1;
				}
				break;
			}
		}
		placeHolder.transform.SetSiblingIndex (newSiblingIndex);
	}

	public void OnEndDrag(PointerEventData pointerData) {
		this.transform.SetParent (parentReturn);
		this.transform.SetSiblingIndex (placeHolder.transform.GetSiblingIndex());
		this.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		Destroy (placeHolder);
	}
}
