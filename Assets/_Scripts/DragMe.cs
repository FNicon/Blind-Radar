using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragMe : MonoBehaviour {

	private Vector3 position;
	public float DragSizeX;
	public float DragSizeY;
	public bool resetEndDrag = true;
	public bool resetScale = true;
	public bool enableImageOnDrag = false;
	private Vector2 initSize;
	private Image image;
	private Sprite imageSprite;
	private Image[] childImage;

	public GameObject[] disableOnDrag;
    private bool firstTime = true;

	void Start () {
		initSize = GetComponent<RectTransform>().sizeDelta;
        position = GetComponent<RectTransform>().position;
        image = GetComponent<Image>();
		childImage = GetComponentsInChildren<Image>();
		imageSprite = image.sprite;
		if(enableImageOnDrag) {
			/*image.color = new Color(255f, 255f, 255f, 0f);
			if(childImage != null) {}
				childImage.color = new Color(255f, 255f, 255f, 0f);*/
			foreach(Image img in childImage) {
				img.color = new Color(255f, 255f, 255f, 0f);
			}
		}
	}

    private void OnDisable()
    {
        EndDrag();
    }

    void Update () {
		
	}

	public void BeginDrag() {
		
		if(enableImageOnDrag) {
			foreach(Image img in childImage) {
				img.color = new Color(255f, 255f, 255f, 255f);
			}
		}

		foreach(GameObject go in disableOnDrag) {
			go.SetActive(false);
		}
			
	}

	public void OnDrag(){ 
		transform.position = Input.mousePosition;
		GetComponent<RectTransform>().sizeDelta = new Vector2(DragSizeX, DragSizeY);
	 }
    
	public void EndDrag() {
		if(resetEndDrag) {
			GetComponent<RectTransform>().position = position;
			if(resetScale)
				GetComponent<RectTransform>().sizeDelta = initSize;
		} else{
			resetEndDrag = true;
		}

		if(enableImageOnDrag) {
			foreach(Image img in childImage) {
				img.color = new Color(255f, 255f, 255f, 0f);
			}
		}

		foreach(GameObject go in disableOnDrag) {
			go.SetActive(true);
		}
			
	}
}