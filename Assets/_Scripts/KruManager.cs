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
    public GameObject[] driverDeadEnabled;
    public GameObject[] driverDeadDisabled;
    public GameObject[] gunnerDeadEnabled;
    public GameObject[] gunnerDeadDisabled;
    public GameObject[] engineerDeadEnabled;
    public GameObject[] engineerDeadDisabled;

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
            
        } else if(i == 2)
        {
            gunnerHealth -= 50;
            
        } else if(i == 3)
        {
            engineerHealth -= 50;
            
        }

        CheckAnyDead();
        UpdateHealth();
    }

    void UpdateHealth()
    {
        driverHealthFill.fillAmount = driverHealth / 100;
        gunnerHealthFill.fillAmount = gunnerHealth / 100;
        engineerHealthFill.fillAmount = engineerHealth / 100;
    }

    void CheckAnyDead()
    {
        if (driverHealth <= 0)
        {
            driverSlot.SetActive(true);
            driver.SetActive(false);
            foreach (GameObject go in driverDeadEnabled)
            {
                go.SetActive(true);
            }
            foreach (GameObject go in driverDeadDisabled)
            {
                go.SetActive(false);
            }
            SubmarineControl.instance.SetIsAllowedControl(false);
            NotificationTrigger.Instance.TriggerNotification(2);
        } else
        {
            driverSlot.SetActive(false);
            driver.SetActive(true);
            foreach (GameObject go in driverDeadEnabled)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in driverDeadDisabled)
            {
                go.SetActive(true);
            }
            SubmarineControl.instance.SetIsAllowedControl(true);
        }

        if(gunnerHealth <= 0)
        {
            gunnerSlot.SetActive(true);
            gunner.SetActive(false);
            foreach (GameObject go in gunnerDeadEnabled)
            {
                go.SetActive(true);
            }
            foreach (GameObject go in gunnerDeadDisabled)
            {
                go.SetActive(false);
            }
            NotificationTrigger.Instance.TriggerNotification(2);
        } else
        {
            gunnerSlot.SetActive(false);
            gunner.SetActive(true);
            foreach (GameObject go in gunnerDeadEnabled)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in gunnerDeadDisabled)
            {
                go.SetActive(true);
            }
        }

        if(engineerHealth <= 0)
        {
            engineerSlot.SetActive(true);
            engineer.SetActive(false);
            foreach (GameObject go in engineerDeadEnabled)
            {
                go.SetActive(true);
            }
            foreach (GameObject go in engineerDeadDisabled)
            {
                go.SetActive(false);
            }
        } else
        {
            engineerSlot.SetActive(false);
            engineer.SetActive(true);
            foreach (GameObject go in engineerDeadEnabled)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in engineerDeadDisabled)
            {
                go.SetActive(true);
            }
        }
    }

    public void Swap(KruType kru1, KruType kru2)
    {
        //driver.GetComponent<DragMe>().EndDrag();
        //gunner.GetComponent<DragMe>().EndDrag();
        //engineer.GetComponent<DragMe>().EndDrag();
        if (kru1 == KruType.Driver && kru2 == KruType.Gunner || kru1 == KruType.Gunner && kru2 == KruType.Driver)
        {
            float tmp = driverHealth;
            driverHealth = gunnerHealth;
            gunnerHealth = tmp;
        } else if (kru1 == KruType.Driver && kru2 == KruType.Engineer || kru1 == KruType.Engineer && kru2 == KruType.Driver)
        {
            float tmp = driverHealth;
            driverHealth = engineerHealth;
            engineerHealth = tmp;
        } else if (kru1 == KruType.Gunner && kru2 == KruType.Engineer || kru1 == KruType.Engineer && kru2 == KruType.Gunner)
        {
            float tmp = engineerHealth;
            engineerHealth = gunnerHealth;
            gunnerHealth = tmp;
        }

        CheckAnyDead();
        UpdateHealth();
    }
}
