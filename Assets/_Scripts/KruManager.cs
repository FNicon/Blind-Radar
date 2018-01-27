using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum KruType { Driver, Gunner, Engineer };

public class KruManager : Singleton<KruManager> {

    public float driverHealth = 100f;
    public Image driverHealthFill;
    public float engineerHealth = 100f;
    public Image engineerHealthFill;
    public float gunnerHealth = 100f;
    public Image gunnerHealthFill;
    public GameObject driverSlot;
    public GameObject gunnerSlot;
    public GameObject engineerSlot;
    public GameObject driver;
    public GameObject engineer;
    public GameObject gunner;

    private void Awake()
    {
        instance = this;
    }

    void Start () {
		
	}
	
	void Update () {
		
	}

    public void ShipDamaged()
    {
        int i = Random.Range(1, 3);
        if(i == 1)
        {
            driverHealth -= 50;
            driverHealthFill.fillAmount = driverHealth / 100;
        } else if(i == 2)
        {
            gunnerHealth -= 50;
            gunnerHealthFill.fillAmount = gunnerHealth / 100;
        } else if(i == 3)
        {
            engineerHealth -= 50;
            engineerHealthFill.fillAmount = engineerHealth / 100;
        }

        CheckAnyDead();
    }

    void CheckAnyDead()
    {
        if(driverHealth <= 0)
        {
            driverSlot.SetActive(true);
            driver.SetActive(false);
        }

        if(gunnerHealth <= 0)
        {
            gunnerSlot.SetActive(true);
            gunner.SetActive(false);
        }

        if(engineerHealth <= 0)
        {
            engineerSlot.SetActive(true);
            engineer.SetActive(false);
        }
    }
}
