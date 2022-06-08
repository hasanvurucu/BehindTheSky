using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeScript : MonoBehaviour {

	private float speed;
	private int wayLeft;//if 1 way is left, else way is right

	void Start () {
		wayLeft = Random.Range (1, 3);
		if (wayLeft == 1)
		{
			speed = Random.Range (-8f, -7f);
		}
		if(wayLeft == 2)
		{
			transform.Rotate (0, 180, 0); //look right
			speed = Random.Range(7f, 8f);
		}

	}


	void Update () {
		Vector2 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.tag == "hitableLimit") 
		{
			speed = -speed;
			transform.Rotate (0, 180, 0);
		}
		if (collision.tag == "objDestroy") 
		{
			Object.Destroy (this.gameObject);
		}

	}
}
