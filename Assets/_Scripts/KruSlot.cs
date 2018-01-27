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

    public void CheckSlot(PointerEventData data)
    {
        data.pointerDrag.transform.SetParent(this.transform);
    }

    public void EnterSlot(PointerEventData data)
    {

    }

    public void ExitSlot(PointerEventData data)
    {

    }
}
