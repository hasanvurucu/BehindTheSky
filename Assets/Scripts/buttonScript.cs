using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour {

	public static int metalResource;
	public static int titaniumResource;

	public float protectionTimer;

	public GameObject playAgainButton;
	public GameObject pauseButton;
	public GameObject unpauseButton;
	public GameObject startGameButton;
	public GameObject buyShieldButton;
	public GameObject buyBoostButton;

	public GameObject pauseMenuPanel;
	public GameObject creditsPanel;

	public GameObject boosterObj;
	public GameObject shieldObj;
	public GameObject loadingPanel;

	public playerScript pScr;
	public cameraMovement camMov;
	public playerMovement pMovSc;
	public resourceManageScript resManageSc;

	private int i;

	public int rewardOrResume = 0; //1 is reward, 2 is resume

	public bool videoWatch = false;

	public bool gamePause;

	public void OnMouseDownPlay()
	{
		loadingPanel.SetActive (true);
		SceneManager.LoadScene ("main");
	}
	public void playAgainInGame()
	{
		SceneManager.LoadScene ("main");
	}/*
	public void quitButton()
	{
		Application.Quit ();
	}*/
	public void storeButton()
	{
	//	loadingPanel.SetActive (true);
		SceneManager.LoadScene ("store");
	}
	public void optionsButton()
	{
		loadingPanel.SetActive (true);
		SceneManager.LoadScene ("options");
	}
	public void howToPlayButton()
	{
		loadingPanel.SetActive (true);
		SceneManager.LoadScene ("howToPlay");
	}
	public void backButtonToMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene ("menu");
	}
	public void playAgain()
	{
		Time.timeScale = 1;
		playAgainButton.SetActive(false);
		SceneManager.LoadScene ("main");
	}
	public void pauseButtonMethod()
	{
		gamePause = true;
		Time.timeScale = 0f;
		pauseButton.SetActive (false);
		unpauseButton.SetActive (true);
		pauseMenuPanel.SetActive (true);
	}
	public void unpauseButtonMethod()
	{
		gamePause = false;
		Time.timeScale = 1f;
		unpauseButton.SetActive (false);
		pauseMenuPanel.SetActive (false);
		pauseButton.SetActive (true);
	}
	public void rewardedVideoWatchButton()
	{
		rewardOrResume = 1;
		videoWatch = true;
	}
	public void videoToResumeButton()
	{
		rewardOrResume = 2;
		videoWatch = true;
	}
	public void skipRequestButton()
	{
		Time.timeScale = 1;
		pScr.waitForInput = true;
		rewardOrResume = 0;
	}
	public void startGame()
	{
		if (protectionTimer >= 0.75f)
		{
			camMov.startGame = true;
			startGameButton.SetActive (false);
			buyShieldButton.SetActive (false);
			buyBoostButton.SetActive (false);
			pMovSc.moveAvaible = true;
			pauseButton.SetActive (true);
		}
	}
	public void buyShield()
	{
		//decrease resources
		if (metalResource >= 20)
		{
			shieldObj.SetActive (true);
			buyShieldButton.SetActive (false);
			for (i = 0; i < 20; i++)
			{
				resManageSc.metalResourceDecrease ();
			}
		}
	}
	public void buyBoost()
	{
		//decrease resources
		if (titaniumResource >= 20)
		{
			boosterObj.SetActive (true);
			buyBoostButton.SetActive (false);
			for (i = 0; i < 20; i++)
			{
				resManageSc.titaniumResourceDecrease ();
			}
		}
	}

	public void goLeaderboard()
	{
	//	loadingPanel.SetActive (true);
		SceneManager.LoadScene ("leaderboard");
	}
	public void creditsButton()
	{
		creditsPanel.SetActive (true);
	}

	void Start () 
	{
		videoWatch = false;
		protectionTimer = 0f;
	}
	void Update()
	{
		protectionTimer += Time.deltaTime;
		metalResource = PlayerPrefs.GetInt ("TheMetalResource", metalResource);
		titaniumResource = PlayerPrefs.GetInt ("TheTitaniumResource", titaniumResource);
	}
}
