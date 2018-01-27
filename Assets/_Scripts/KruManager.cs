using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum KruType { Driver, Gunner, Engineer };

public class KruManager : MonoBehaviour {

    public float driverHealth = 100f;
    public Image driverHealthFill;
    public float engineerHealth = 100f;
    public Image engineerHealthFill;
    public float gunnerHealth = 100f;
    public Image gunnerHealthFill;

    void Start () {
		
	}
	
	void Update () {
		
	}
}
