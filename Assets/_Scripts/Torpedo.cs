using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public class Torpedo : MonoBehaviour {

	public float incSpeed = 1.0f, maxSpeed = 10.0f;
    public float damage;
	public float disappearTime = 10.0f;
    public GameObject hitfx;
	private Rigidbody2D rigidBody;
	private GameObject particle;
	private float curTime;

	// Use this for initialization
	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
		particle = gameObject.transform.GetChild (0).gameObject;

		particle.transform.localEulerAngles = new Vector3 ((transform.eulerAngles.z * -1 - 90), -90, -90);
		curTime = 0;
	}

	// Update is called once per frame
	void Update () {
		//if (rigidBody.velocity.x < maxSpeed)
		//	rigidBody.velocity += new Vector2 (incSpeed, 0);

		curTime += Time.deltaTime;
		if (curTime > disappearTime) {
			Instantiate(hitfx, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}

		if (rigidBody.velocity.magnitude < maxSpeed)
			rigidBody.AddForce (transform.right * -incSpeed * 50);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<SubmarineControl>().ChangeHealth(-damage);
            Instantiate(hitfx, transform.position, transform.rotation);
            ProCamera2DShake.Instance.Shake(0);
            Destroy(this.gameObject);
        } else if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(hitfx, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
