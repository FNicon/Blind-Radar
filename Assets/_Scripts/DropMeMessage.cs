using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class DropMeMessage : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public string OnEnterMessage;
	public string OnExitMessage;
	public string OnDropMessage;
	
	public void OnDrop(PointerEventData data)
	{
		if(data.pointerDrag != null)
			this.gameObject.SendMessage(OnDropMessage, data);
	}

	public void OnPointerEnter(PointerEventData data)
	{
		if(data.pointerDrag != null)
			this.gameObject.SendMessage(OnEnterMessage, data);
	}

	public void OnPointerExit(PointerEventData data)
	{
		if(data.pointerDrag != null)
			this.gameObject.SendMessage(OnExitMessage, data);
	}
}