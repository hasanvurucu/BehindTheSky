using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScript : MonoBehaviour {

	public cameraMovement camMov;
	/*
	public Transform backgrounds1;
	public Transform backgrounds2;*/
	public GameObject backgrounds1;
	public GameObject backgrounds2;
	/*
	public Transform spaceBG1;
	public Transform spaceBG2;*/
	public GameObject spaceBG1;
	public GameObject spaceBG2;

	public Transform mainBG;

	public GameObject sky0;

	private bool backGroundSelect = false;
	private bool backGroundSelectSPACE = false;

	private float positionTemp = 0;
	private float positionWholeTemp = 0;
	private float positionTempSPACE = 0;
	private float positionWholeTempSPACE = 0;

	private float speedBG;

	void Start () 
	{
		
	}
	void Update () 
	{
		if (camMov.score <= 950)
		{
			spaceBG1.SetActive (false);
			spaceBG2.SetActive (false);
		} else
		{
			spaceBG1.SetActive (true);
			spaceBG2.SetActive (true);
		}
		if (camMov.score >= 1500)
		{
			backgrounds1.SetActive (false);
			backgrounds2.SetActive (false);
		}
		speedBG = (camMov.speed) * (0.4f);

		Vector3 bg1pos = backgrounds1.transform.position;
		Vector3 bg2pos = backgrounds2.transform.position;
		Vector3 spaceBG1pos = spaceBG1.transform.position;
		Vector3 spaceBG2pos = spaceBG2.transform.position;

		Vector3 mainPos = mainBG.transform.position;

		mainPos.y += speedBG * Time.deltaTime;

		positionTemp = camMov.score - (mainPos.y + positionWholeTemp);

		if (camMov.score <= 1500)
		{
			bg1pos.y += speedBG * Time.deltaTime;
			bg2pos.y += speedBG * Time.deltaTime;
			//WORLD ATMOSPHERE
			if (positionTemp >= 63f)
			{
				//push bgs here
				if (backGroundSelect == false)
				{
					sky0.SetActive (false);
					bg1pos.y += 126f;
					backGroundSelect = true;
				} else
				{
					bg2pos.y += 126f;
					backGroundSelect = false;
				}
				positionWholeTemp += 63f;
				positionTemp = 0;
			}
		} 

		//spacePush

		positionTempSPACE = camMov.score - ((mainPos.y * 2) + positionWholeTempSPACE);

		spaceBG1pos.y += (speedBG *2) * Time.deltaTime;
		spaceBG2pos.y += (speedBG *2) * Time.deltaTime;
		if (positionTempSPACE >= 336 + 21)
		{
			//push bgs here
			if (backGroundSelectSPACE == false)
			{
				spaceBG1pos.y += 672;
				backGroundSelectSPACE = true;
			} else
			{
				spaceBG2pos.y += 672;
				backGroundSelectSPACE = false;
			}
			positionWholeTempSPACE += 336;
			positionTempSPACE = 0;
		}

		mainBG.transform.position = mainPos;
		spaceBG1.transform.position = spaceBG1pos;
		spaceBG2.transform.position = spaceBG2pos;
		backgrounds1.transform.position = bg1pos;
		backgrounds2.transform.position = bg2pos;
	}


}
