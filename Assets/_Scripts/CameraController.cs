using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public class CameraController : Singleton<CameraController> {

    private Transform lastTorpedo;
    private Transform player;

    private void Awake()
    {
        instance = this;
    }

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update () {
		
	}

    public void SetLastTorpedo(Transform t)
    {
        lastTorpedo = t;
    }

    public void FollowUp()
    {
        if(lastTorpedo != null)
        {
            ProCamera2D.Instance.RemoveAllCameraTargets();
            ProCamera2D.Instance.AddCameraTarget(lastTorpedo);
            ProCamera2D.Instance.HorizontalFollowSmoothness = 0.1f;
            ProCamera2D.Instance.VerticalFollowSmoothness = 0.1f;
        }
    }

    public void Unfollow()
    {
        ProCamera2D.Instance.RemoveAllCameraTargets();
        ProCamera2D.Instance.AddCameraTarget(player, 1f, 1f, 0, new Vector2(4f,0));
        ProCamera2D.Instance.HorizontalFollowSmoothness = 2.5f;
        ProCamera2D.Instance.VerticalFollowSmoothness = 1.5f;
        ProCamera2D.Instance.Reset();
    }
}
