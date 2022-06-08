using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boosterPointScript : MonoBehaviour {

	void Start () {
		
	}

	void Update () 
	{
		transform.Rotate (new Vector3(0, 80, 0) * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player") 
		{
			Object.Destroy (this.gameObject);
		}
	}
}
