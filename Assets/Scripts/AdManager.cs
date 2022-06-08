using System;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds;

public class AdManager : MonoBehaviour {

	public RewardBasedVideoAd rewardBasedVideo;
	public InterstitialAd interstitial;

	public static int interstitialCounter;

	public playerScript pScript;

	public resourceManageScript resManageScript;

	public buttonScript buttScript;

	public GameObject watchVideoButton;

	private int i;

	public void interstitialIncrease()
	{
		interstitialCounter++;
	}

	void Start () 
	{
		MobileAds.Initialize ("ca-app-pub-7543778288796089~4335770378");//uygulama kimliği

		Debug.Log ("interstitialCounter is: " + interstitialCounter);

		RequestInterstitial ();

		rewardBasedVideo = RewardBasedVideoAd.Instance;

	//	rewardBasedVideo.OnAdClosed += HandleOnAdClosed;
	//	rewardBasedVideo.OnAdFailedToLoad += HandleOnAdFailedToLoad;
	//	rewardBasedVideo.OnAdLeavingApplication += HandleOnAdLeavingApplication;
	//	rewardBasedVideo.OnAdLoaded += HandleOnAdLoaded;
	//	rewardBasedVideo.OnAdOpening += HandleOnAdOpening;
		rewardBasedVideo.OnAdRewarded += HandleOnAdRewarded;
	//	rewardBasedVideo.OnAdStarted += HandleOnAdStarted;

		if (!(rewardBasedVideo.IsLoaded ()))
		{
			RequestRewardBased ();
		}

	}
	public void Update () 
	{

		if (interstitialCounter == 2)
		{
			showInterstitial ();
			interstitialCounter = 0;
		}

		if (buttScript.videoWatch == true)
		{
			showRewardBased ();
			watchVideoButton.SetActive (false);
			buttScript.videoWatch = false;
			pScript.waitForInput = true;
		}
	}

	public void RequestInterstitial()
	{
		string adUnitId = "ca-app-pub-7543778288796089/4499421906";
		//ca-app-pub-7543778288796089/4499421906 //orjinal kimlik - interstitial
		//ca-app-pub-3940256099942544/8691691433 //tester video

		interstitial = new InterstitialAd (adUnitId);

		AdRequest request = new AdRequest.Builder ().Build ();

		interstitial.LoadAd (request);
	}

	public void showInterstitial()
	{
		if (interstitial.IsLoaded ())
		{
			interstitial.Show();
		}
	}

	public void RequestRewardBased()
	{
		string adUnitId = "ca-app-pub-7543778288796089/4005378137";
		//ca-app-pub-7543778288796089/4005378137 //orjinal kimlik - rewardbased
		//ca-app-pub-3940256099942544/5224354917 //tester

		rewardBasedVideo.LoadAd (new AdRequest.Builder ().Build (), adUnitId);
	}

	public void showRewardBased()
	{
		if (rewardBasedVideo.IsLoaded ())
		{
			rewardBasedVideo.Show ();
		}
	}

	/*
	public void HandleOnAdLoaded(object sender, EventArgs args)
	{
		//Make an offer to user.
	}
	public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		//Try a reload.
	}
	public void HandleOnAdOpening(object sender, EventArgs args)
	{
		//Pause the action.
	}
	public void HandleOnAdStarted(object sender, EventArgs args)
	{
		//Ex: mute audio
	}*/ /*
	public void HandleOnAdClosed(object sender, EventArgs args)
	{
		
		//No rewards because ad is closed!
	} */
	public void HandleOnAdRewarded(object sender, Reward args)
	{
		//Reward the user.
		if (buttScript.rewardOrResume == 1)
		{
			//rewards are resources
			for (i = 0; i < 10; i++)
			{
				resManageScript.metalResourceIncrease ();
				resManageScript.titaniumResourceIncrease ();
			}
			buttScript.rewardOrResume = 0;
		} else if (buttScript.rewardOrResume == 2)
		{
			//reward is resuming the game
			pScript.death = false;
			pScript.pauseButton.SetActive (true);
			pScript.timerDeath = 0f;
			pScript.videoToResumeButton.SetActive (false);
			pScript.skipRequestButton.SetActive (false);
			pScript.afterBoost = true; //send 1 second of temporary protection after the video ad.
			pScript.gameObject.GetComponent<Collider2D>().enabled = false;
			pScript.boostShield.SetActive (true);
			Time.timeScale = 1;
			buttScript.rewardOrResume = 0;
		}


	}/*
	public void HandleOnAdLeavingApplication(object sender, EventArgs args)
	{
		//No rewards because user quited the app!
	} */

	public event EventHandler<EventArgs> OnAdLoaded;

//	public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

//	public event EventHandler<EventArgs> OnAdOpening;

//	public event EventHandler<EventArgs> OnAdStarted;

//	public event EventHandler<EventArgs> OnAdClosed;

	public event EventHandler<Reward> OnAdRewarded;

//	public event EventHandler<EventArgs> OnAdLeavingApplication;

//	public event EventHandler<EventArgs> OnAdCompleted;

}
