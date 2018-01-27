using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler{

	public void OnPointerEnter(PointerEventData pointerData) {
		if (pointerData.pointerDrag == null) {
			return;
		}
		Dragable d = pointerData.pointerDrag.GetComponent<Dragable> ();
		if (d != null) {
			d.parentTemp = this.transform;
		}
	}

	public void OnPointerExit(PointerEventData pointerData) {
		if (pointerData.pointerDrag == null) {
			return;
		}
		Dragable d = pointerData.pointerDrag.GetComponent<Dragable> ();
		if (d != null && d.parentTemp == this.transform) {
			d.parentTemp = d.parentReturn;
		}
	}

	public void OnDrop(PointerEventData pointerData) {
		Dragable d = pointerData.pointerDrag.GetComponent<Dragable> ();
		if (d != null) {
			d.parentReturn = this.transform;
		}
	}
}
