using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuBackGr : MonoBehaviour {

	public float speed;

	public static Vector3 pos = new Vector3 (0f, 0f, 0f);

	void Start () {
		speed = 0.2f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		pos.x -= speed * Time.deltaTime;

		if (pos.x <= -12) 
		{
			pos.x = 0f;
		}
		transform.position = pos;
	}
}
