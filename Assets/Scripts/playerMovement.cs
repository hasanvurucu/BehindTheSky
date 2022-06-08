using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	Vector3 offset;
	public GameObject Player;

	public bool moveAvaible = false;

	public cameraMovement camMovSc;
	public playerScript pScr;
	public buttonScript buttonSc;

	float actualSpeed;

	float distance = 10f;

//	private bool touchCheck;

	void Start()
	{
//		touchCheck = false;
		offset = Player.transform.position - transform.position;
		//Player.transform.position = transform.position + offset;
		gameObject.GetComponent<Collider2D> ().enabled = false;
	}

	void Update()
	{
		if (moveAvaible == true)
		{
			gameObject.GetComponent<Collider2D> ().enabled = true;
			moveAvaible = false;
		}
		Vector3 objPosition = transform.position;

		if (pScr.death == false)
		{
			if (pScr.boostMechanism == true)
			{
				actualSpeed = camMovSc.speedClone * 5;
			} else if (Input.GetMouseButton (0))
			{
				actualSpeed = camMovSc.speedClone;
			} else
			{
				actualSpeed = camMovSc.speedClone / 10;
			}
		} else
		{
			actualSpeed = 0;
		}

		if (pScr.death == false)
		{
			objPosition.y += actualSpeed * Time.deltaTime;
			//yAxisHold(?) += actualSpeed * Time.deltaTime;
		}

		Player.transform.position = transform.position + offset;

		transform.position = objPosition;
	}

	void FixedUpdate()
	{
		
	}
	void OnMouseDrag()
	{
		if (pScr.death == false && buttonSc.gamePause == false)
		{
//			touchCheck = true;
			Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
			Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
			transform.position = objPosition;
		//	Player.transform.position = transform.position + offset;
		}
	}
}
