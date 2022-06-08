using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class cameraMovement : MonoBehaviour {

	public bool startGame = false;

	public float speed;
	public float speedClone;
	public float speedTimer;
	public float updateSpeed;

	public playerScript pScr;

	public Text scoreText;
	public Text hiScoreText;
	//public Text metalResourceText;
	//public Text titaniumResourceText;

	public int score = 0;
	private int scoreHold = 0;
	private int scoreExTemp = 0;

	public static int highscore;
	public static int metalResource;
	public static int titaniumResource;

	public buttonScript buttScr;

	public Rigidbody2D rb;

	void Start () {
		score = 0;
		SetScoreText ();

		speedClone = 0f;
		//speedClone = 1f;

		highscore = PlayerPrefs.GetInt ("Highscore", highscore);
	}

	void Update () {

		if (startGame == true)
		{
			speedClone = 1f;
			startGame = false;
		}

		if(buttScr.gamePause == false)
		{
		
		if (score > highscore) 
		{
			highscore = score;
		}
		PlayerPrefs.SetInt ("Highscore", highscore);

		SetHiScoreText ();
		//SetMetalResourceText ();
		//SetTitaniumResourceText ();



		Vector3 pos = new Vector3(transform.position.x, transform.position.y, -10f);

		score = (int)pos.y;
		SetScoreText ();

		scoreHold = score - scoreExTemp;
		if(score > -1f && score <=10)
		{
			if(scoreHold >= 1)
			{
				speedClone += 1.2f;
				scoreExTemp += scoreHold;
				scoreHold = 0;
			}
		}
		else if (score < 1500 && score > 10) 
		{
			if (scoreHold >= 75) 
			{
				speedClone += 0.35f;
				scoreExTemp += scoreHold;
				scoreHold = 0;
			}
		} 
		else if (score > 1500 && score < 5000) 
		{
			if (scoreHold >= 500) 
			{
				speedClone += 0.5f;
				scoreExTemp += scoreHold;
				scoreHold = 0;
			}
		} 
		else if (score > 5000 && score < 100000) 
		{
			if (scoreHold >= 1000) 
			{
				speedClone += 0.2f;
				scoreExTemp += scoreHold;
				scoreHold = 0;
			}
		} 
		else 
		{
			if (scoreHold >= 100000) 
			{
				speedClone += 1f;
				scoreExTemp = scoreHold;
				scoreHold = 0;
			}
		}


		if (pScr.death == false) 
		{
			if (pScr.boostMechanism == true)
			{
				speed = speedClone * 5;
			}
			else if (Input.GetMouseButton (0)) 
			{
				speed = speedClone;
			} 
			else 
			{
				speed = speedClone / 10;
			}
		} 
		else 
		{
			speed = 0;
		}

		if(speed > 0){
			pos.y += speed * Time.deltaTime;
		}

		//IMPORTANT
		transform.position = pos;

		}
	}

	public void SetScoreText()
	{
		scoreText.text = "Score: " + score.ToString ();
	}
	public void SetHiScoreText()
	{
		hiScoreText.text = "Highscore: " + highscore.ToString ();
	}
}
