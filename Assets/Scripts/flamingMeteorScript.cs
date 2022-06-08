using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flamingMeteorScript : MonoBehaviour {

	private float speed;

	void Start () {

		speed = Random.Range (3f, 5.5f);

		transform.Rotate (new Vector3(0, 0, 45));

	}


	void Update () {

		Vector2 pos = transform.position;
		pos.y -= speed * Time.deltaTime;
		transform.position = pos;
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.tag == "hitableLimit") 
		{
			speed = -speed;
		}
		if (collision.tag == "objDestroy") 
		{
			Object.Destroy (this.gameObject);
		}

	}

}
