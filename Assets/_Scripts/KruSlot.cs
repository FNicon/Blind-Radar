using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KruSlot : MonoBehaviour {

    public KruType kruType;

	void Start () {
		
	}

	void Update () {
		
	}

    public void DropSlot(PointerEventData data)
    {
        KruManager.Instance.Swap(data.pointerDrag.GetComponent<KruSlot>().kruType, kruType);   
    }

    public void EnterSlot(PointerEventData data)
    {

    }

    public void ExitSlot(PointerEventData data)
    {

    }
}
