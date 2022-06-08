using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerScript : MonoBehaviour {

	public Sprite ShipSprite1;
	public Sprite ShipSprite2;
	public Sprite ShipSprite3;
	public Sprite ShipSprite4;
	public Sprite ShipSprite5;
	public Sprite ShipSprite6;

	//variables for shield
	public bool shieldStatus; //call these variables by a buy button at the start.
	public GameObject shieldReference;
	public bool shieldBlast = false;
	public GameObject shieldBlastEffect;
	public float shieldBlastTimer;

	//variables for boost algorithm
	public bool boostMechanism;
	public float boostTimer;
	public GameObject boostSound;
	public bool afterBoost;
	public float afterBoostTimer;
	public GameObject boostEffect;
	public GameObject boostShield;

	public static int selectedShipNumb;//range for selected ship sprite

	public float playerSpeed;
//	private float updateSpeed = 0;
//	private float yAxisHold = 0;

	public float timer = 0;
	public float timerDeath = 0;

	public bool multiHitProtection;
	public bool death;
	public bool videoRequest;
	public bool waitForInput = false;
	public bool interstitialIncAllow = false;

	public cameraMovement camMovSc;

	public resourceManageScript resManage;

	public buttonScript buttonScr;

//	public objSpawnTrigScript objSpawn;

	public AdManager adManagerScript;

	public GameObject playAgainButton;
	public GameObject backToMenuButton;
	public GameObject storeButton;
	public GameObject pauseButton;
	public GameObject watchVideoButton;
	public GameObject videoToResumeButton;
	public GameObject skipRequestButton;

	public GameObject explosionPlayer;
	public GameObject playerFlameEffect;
	public GameObject playerFlameEffect2;

	public bool speedIncrease = true;

	public Rigidbody2D rb;

	void Start () 
	{
		gameObject.GetComponent<Collider2D> ().enabled = true;

		boostTimer = 0f;
		afterBoostTimer = 0f;
		shieldBlastTimer = 0f;
		boostMechanism = false;
		afterBoost = false;
		shieldBlast = false;

		selectedShipNumb = PlayerPrefs.GetInt ("SelectedShipNumb", selectedShipNumb);
		if (selectedShipNumb == 1) 
		{
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = ShipSprite1;
		}
		else if(selectedShipNumb == 2)
		{
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = ShipSprite2;
		}
		else if(selectedShipNumb == 3)
		{
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = ShipSprite3;
		}
		else if(selectedShipNumb == 4)
		{
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = ShipSprite4;
		}
		else if(selectedShipNumb == 5)
		{
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = ShipSprite5;
		}
		else if(selectedShipNumb == 6)
		{
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = ShipSprite6;
		}
		Time.timeScale = 1;
		death = false;
		videoRequest = false;

	}

	private void OnMouseDrag(){}

	void Update () {

		//shield blast mechanishm
		if (shieldBlast == true)
		{
			shieldBlastTimer += Time.deltaTime;
		}
		if(shieldBlastTimer >= 2.5f)
		{
			shieldBlastEffect.SetActive (false);
			shieldBlast = false;
			shieldBlastTimer = 0f;
		}

		//start of the boost mechanism
		if (boostMechanism == true)
		{
			boostTimer += Time.deltaTime;
		}

		if (boostTimer >= 4f)
		{
			boostSound.SetActive (false);
			boostEffect.SetActive (false);
			boostTimer = 0f;
			afterBoost = true;
			boostMechanism = false;
		}
		if (afterBoost == true)
		{
			afterBoostTimer += Time.deltaTime;
		}
		if (afterBoostTimer >= 2f)
		{
			gameObject.GetComponent<Collider2D> ().enabled = true;
			boostShield.SetActive (false);
			afterBoost = false;
			afterBoostTimer = 0f;
		}
		//end of the boost mechanism

		if (death == false)
		{
			gameObject.GetComponent<Renderer> ().enabled = true;
			explosionPlayer.SetActive(false);
		}

		if (death == true && timerDeath < 1.76f) 
		{
			timerDeath += Time.deltaTime;
			videoRequest = true;
		}
		else if (timerDeath >= 1.75f)
		{
			if (videoRequest == true && adManagerScript.rewardBasedVideo.IsLoaded () && waitForInput == false)
			{
				interstitialIncAllow = true;
				videoToResumeButton.SetActive (true);
				skipRequestButton.SetActive (true);

				//Time.timeScale = 0;
			} else if((buttonScr.rewardOrResume != 2) && (waitForInput == true/*Time.timeScale == 1*/ || !(adManagerScript.rewardBasedVideo.IsLoaded ())))
			{
				videoToResumeButton.SetActive (false);
				skipRequestButton.SetActive (false);
				//Time.timeScale = 0;
				playAgainButton.SetActive (true);
				backToMenuButton.SetActive (true);
				storeButton.SetActive (true);
				if (interstitialIncAllow == true)
				{
					adManagerScript.interstitialIncrease ();
					interstitialIncAllow = false;
				}
				if (adManagerScript.rewardBasedVideo.IsLoaded ())
				{
					watchVideoButton.SetActive (true);
				}
				timerDeath = 0f;
			}
		}
		else if (timerDeath >= 2f)
		{
		/*	videoToResumeButton.SetActive (false);
			skipRequestButton.SetActive (false);
			Time.timeScale = 0;
			playAgainButton.SetActive (true);
			backToMenuButton.SetActive (true);
			storeButton.SetActive (true);
			adManagerScript.interstitialIncrease ();
			if (adManagerScript.rewardBasedVideo.IsLoaded ())
			{
				watchVideoButton.SetActive (true);
			}
			timerDeath = 0f; */
		}
		
		Vector2 pos = transform.position;
		if (death == false)
		{
			if (boostMechanism == true)
			{
				playerSpeed = camMovSc.speedClone * 5;
			} else if (Input.GetMouseButton (0))
			{
				playerSpeed = camMovSc.speedClone;
			} else
			{
				playerSpeed = camMovSc.speedClone / 10;
			}
		}

		if (death == false)
		{
			pos.y += playerSpeed * Time.deltaTime;
			//	yAxisHold(?) += playerSpeed * Time.deltaTime;
		}

		//IMPORTANT
		transform.position = pos;

		timer += Time.deltaTime;
		if (timer < 5f)
			multiHitProtection = false;
		else
			multiHitProtection = true;
	}

	private void OnCollisionEnter2D (Collision2D collision)
	{
		//sample physical collision
		if (collision.gameObject.tag == "sampleTag") 
		{
			//physical collisions
		}

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "limit") 
		{
			if (shieldStatus == false)
			{
				explosionPlayer.SetActive (true);
				playerFlameEffect.SetActive (false);
				playerFlameEffect2.SetActive (false);
				gameObject.GetComponent<Renderer> ().enabled = false;
				death = true;
				pauseButton.SetActive (false);
			} else //(shieldStatus == true)
			{
				shieldStatus = false;
				shieldReference.SetActive (false);
				shieldBlast = true;
				shieldBlastEffect.SetActive (true);

			}
		}
		if (collision.gameObject.tag == "metalResource") 
		{
			resManage.metalResourceIncrease ();
		}
		if (collision.gameObject.tag == "titaniumResource") 
		{
			resManage.titaniumResourceIncrease ();
		}

		if (multiHitProtection == true) 
		{
			if (collision.tag == "triggerLimit") 
			{
				collision.gameObject.transform.parent.root.GetComponent<limitTrigger> ().Invoke ("triggerMethod", 5f);
				timer = 0f;
			}
		}
		if (collision.gameObject.tag == "boost")
		{
			boostMechanism = true;
			gameObject.GetComponent<Collider2D> ().enabled = false;
			boostSound.SetActive (true);
			boostEffect.SetActive (true);
			boostShield.SetActive (true);
		}
		if (collision.gameObject.tag == "collectableShield")
		{
			shieldStatus = true;
			shieldReference.SetActive (true);
		}

	/*	if (collision.tag == "objSpawnTrigger") 
		{
			objSpawn.objSpawnTriggerMethod ();
		} */
	}
}
