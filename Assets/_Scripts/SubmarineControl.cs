using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Com.LuisPedroFonseca.ProCamera2D;

[RequireComponent(typeof(Rigidbody2D))]
public class SubmarineControl : Singleton<SubmarineControl> {
    public Vector2 initVelocity;
    public Slider horizontalAccelerationSlider;
    public Slider verticalAccelerationSlider;
    public Image healthFill;
    public float dragDelay = 5f;
    public float maxHealth = 100f;
    public GameObject torpedo;
    public Transform torpedoSpawnPoint;
    public GameObject submarineInterior;

    private Rigidbody2D rb;
    private float horizontalAcceleration;
    private float verticalAcceleration;
    private float currentHealth;
    private Transform lastTorpedo;
    private bool isAllowedControl = true;

    //public NotificationTrigger notificationHurt;

    private void Awake()
    {
        instance = this;
    }

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
	}

	void Update () {
        Vector2 desiredVelocity = new Vector2(horizontalAcceleration / 100f, verticalAcceleration / 100f);
        desiredVelocity += initVelocity;
        rb.velocity = desiredVelocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireTorpedo();
        }
    }

    public void ChangeHorizontalAcceleration()
    {
        DOTween.To(() => horizontalAcceleration, x => horizontalAcceleration = x, horizontalAccelerationSlider.value, dragDelay);
    }

    public void ChangeVerticalAcceleration()
    {
        DOTween.To(() => verticalAcceleration, x => verticalAcceleration = x, verticalAccelerationSlider.value, dragDelay);
    }

    public void ChangeHealth(float val)
    {
		//notificationHurt.TriggerNotification (1);
        currentHealth += val;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthFill.fillAmount = currentHealth / 100f;
        if(val < 0)
        {
            KruManager.Instance.ShipDamaged();
            NotificationTrigger.Instance.TriggerNotification(1);
        }

        if(currentHealth <= 0)
        {
            Dead();
        }
        
    }

    void Dead()
    {

    }

    public void FireTorpedo()
    {
        GameObject g = Instantiate(torpedo, torpedoSpawnPoint.position, torpedoSpawnPoint.rotation) as GameObject;
        CameraController.Instance.SetLastTorpedo(g.transform);
    }

    public void SetIsAllowedControl(bool b)
    {
        isAllowedControl = b;
    }

    public bool GetIsAllowedControl()
    {
        return isAllowedControl;
    }

    public void Repair()
    {
        ChangeHealth(25);
    }

}
