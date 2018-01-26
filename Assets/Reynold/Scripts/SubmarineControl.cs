using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class SubmarineControl : MonoBehaviour {
    public Slider horizontalAccelerationSlider;
    public Slider verticalAccelerationSlider;
    public float dragDelay = 5f;
    private Rigidbody2D rb;
    private float horizontalAcceleration;
    private float verticalAcceleration;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

	void Update () {
        Vector2 desiredVelocity = new Vector2(horizontalAcceleration / 100f, verticalAcceleration / 100f);
        rb.velocity = desiredVelocity;
    }

    public void ChangeHorizontalAcceleration()
    {
        DOTween.To(() => horizontalAcceleration, x => horizontalAcceleration = x, horizontalAccelerationSlider.value, dragDelay);
    }

    public void ChangeVerticalAcceleration()
    {
        DOTween.To(() => verticalAcceleration, x => verticalAcceleration = x, verticalAccelerationSlider.value, dragDelay);
    }
}
