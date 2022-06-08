using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienShotScript : MonoBehaviour {

	private float speed;

	void Start () {
		speed = 8f;	
	}

	void Update () {
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		pos.y -= speed * Time.deltaTime;
		transform.position = pos;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "objDestroy") 
		{
			Object.Destroy (this.gameObject);
		}
		if(collision.tag == "Player")
		{
			Object.Destroy (this.gameObject);
		}
	}
}
