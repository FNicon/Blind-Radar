using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Slider horizontalSlider;
    public Slider verticalSlider;
    public float timeBetween = 0.33f;

    private float timestampHorizontal;
    private float timestampVertical;

    void Start () {
		
	}

	void Update () {
        if (Time.time >= timestampHorizontal && (Input.GetKey(KeyCode.A)))
        {
            horizontalSlider.value--;
            timestampHorizontal = Time.time + timeBetween;
        }
        else if (Time.time >= timestampHorizontal && (Input.GetKey(KeyCode.D)))
        {
            horizontalSlider.value++;
            timestampHorizontal = Time.time + timeBetween;
        }

        if (Time.time >= timestampVertical && (Input.GetKey(KeyCode.S)))
        {
            verticalSlider.value--;
            timestampVertical = Time.time + timeBetween;
        }
        else if (Time.time >= timestampVertical && (Input.GetKey(KeyCode.W)))
        {
            verticalSlider.value++;
            timestampVertical = Time.time + timeBetween;
        }
    }
}
