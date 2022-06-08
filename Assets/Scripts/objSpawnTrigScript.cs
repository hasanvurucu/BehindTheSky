using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objSpawnTrigScript : MonoBehaviour {

	public cameraMovement camMovSc;
	public Transform cameraTransform;

	public GameObject cloudPrefab;
	public static GameObject cloneCloud;

	public GameObject alienShip;
	public static GameObject cloneAlienShip;

	public GameObject ufoPrefab;
	public static GameObject cloneUfoPrefab;

	public GameObject flamingMetPrefab;
	public static GameObject cloneFlamingMet;

	public GameObject planePrefab;
	public static GameObject clonePlanePrefab;

	public GameObject metalResourcePrefab;
	public static GameObject cloneMetalResource;

	public GameObject titaniumResourcePrefab;
	public static GameObject cloneTitaniumResource;

	public GameObject boosterPrefab;
	public static GameObject cloneBooster;

	public GameObject shieldPrefab;
	public static GameObject cloneShield;

	private float spawnRange = 0;
	public float spawnRangeOfx = 0;
	private float spawnRangeForSpecials;

	private int objSpawnChanceRange;
	private int objXAxisSpawnRange;

	public bool triggerMethod = false;
	public bool trigForResources = false;

	void Start () {
		spawnRange = 5;
		spawnRangeForSpecials = 25f;
	}

	void Update () {
		Vector3 pos = transform.position;
		if (pos.y - cameraTransform.position.y <= -10)
		{
			pos.y = cameraTransform.position.y + 10;
			transform.position = pos;
		}
		Vector3 spawnPos = transform.position;
		spawnPos.y = 10f + transform.position.y;
		if (triggerMethod == true) 
		{
			if (camMovSc.score <= 1000)
			{
				//DUNYA OBJELERINI BURADAN SPAWNLA
				objSpawnChanceRange = Random.Range (1, 8);
				if (objSpawnChanceRange > 0 && objSpawnChanceRange < 5)
				{
					spawnRange = 9f;//spawnrange for clouds on Y axis
					objXAxisSpawnRange = Random.Range (-10, 10);
					spawnPos.y += spawnRange;
					spawnPos.x = transform.position.x + objXAxisSpawnRange;
					cloneCloud = (GameObject)Instantiate (cloudPrefab, spawnPos, transform.rotation);

					transform.position = new Vector3 (transform.position.x, transform.position.y + spawnRange, transform.position.z);

					triggerMethod = false;
				} else if (objSpawnChanceRange > 4 && objSpawnChanceRange < 7)
				{
					spawnRange = 9f;//spawnrange for planes on Y axis
					objXAxisSpawnRange = Random.Range (-10, 10);
					spawnPos.y += spawnRange;
					spawnPos.x = transform.position.x + objXAxisSpawnRange;
					clonePlanePrefab = (GameObject)Instantiate (planePrefab, spawnPos, transform.rotation);

					transform.position = new Vector3 (transform.position.x, transform.position.y + spawnRange, transform.position.z);

					triggerMethod = false;
				}

				triggerMethod = false;
			} else if (camMovSc.score > 1000 && camMovSc.score <= 1750)
			{
				objSpawnChanceRange = Random.Range (1, 9);
				if (objSpawnChanceRange > 0 && objSpawnChanceRange <= 4)
				{
					spawnRange = 5f;//spawnrange for flaming meteors on Y axis
					objXAxisSpawnRange = Random.Range (-10, 10);
					spawnPos.y += spawnRange + 5f;
					spawnPos.x = transform.position.x + objXAxisSpawnRange;
					cloneFlamingMet = (GameObject)Instantiate (flamingMetPrefab, spawnPos, transform.rotation);

					transform.position = new Vector3 (transform.position.x, transform.position.y + spawnRange, transform.position.z);

					triggerMethod = false;
				} else
				{
					spawnRange = 8f;//spawnrange for NOTHING
					objXAxisSpawnRange = Random.Range (-10, 10);
					spawnPos.y += spawnRange + 5f;
					spawnPos.x = transform.position.x + objXAxisSpawnRange;

					transform.position = new Vector3 (transform.position.x, transform.position.y + spawnRange, transform.position.z);

					triggerMethod = false;
				}

			} else if (camMovSc.score > 1750 && camMovSc.score <= 2250)
			{
				objSpawnChanceRange = Random.Range (1, 12);//ufos, meteors or nothing

				if (objSpawnChanceRange > 0 && objSpawnChanceRange <= 3)
				{
					spawnRange = 5f;//spawnrange for flaming meteors on Y axis
					objXAxisSpawnRange = Random.Range (-10, 10);
					spawnPos.y += spawnRange + 5f;
					spawnPos.x = transform.position.x + objXAxisSpawnRange;
					cloneFlamingMet = (GameObject)Instantiate (flamingMetPrefab, spawnPos, transform.rotation);

					transform.position = new Vector3 (transform.position.x, transform.position.y + spawnRange, transform.position.z);

					triggerMethod = false;
				} else if (objSpawnChanceRange > 3 && objSpawnChanceRange <= 8)
				{
					spawnRange = 6f;//spawnrange for ufos on Y axis
					objXAxisSpawnRange = Random.Range (-10, 10);
					spawnPos.y += spawnRange + 5f;
					spawnPos.x = transform.position.x + objXAxisSpawnRange;
					cloneUfoPrefab = (GameObject)Instantiate (ufoPrefab, spawnPos, transform.rotation);

					transform.position = new Vector3 (transform.position.x, transform.position.y + spawnRange, transform.position.z);

					triggerMethod = false;
				} else
				{
					spawnRange = 8f;//spawnrange for NOTHING
					objXAxisSpawnRange = Random.Range (-10, 10);
					spawnPos.y += spawnRange + 5f;
					spawnPos.x = transform.position.x + objXAxisSpawnRange;

					transform.position = new Vector3 (transform.position.x, transform.position.y + spawnRange, transform.position.z);

					triggerMethod = false;
				}


			} else if (camMovSc.score > 2250 && camMovSc.score <= 3500)
			{
				//SPACE OBJECTS AND NOTHING
				objSpawnChanceRange = Random.Range (1, 14);
				if (objSpawnChanceRange > 0 && objSpawnChanceRange <= 3)
				{
					spawnRange = 20f;//spawnrange for alienShips on Y axis
					objXAxisSpawnRange = Random.Range (-10, 10);
					spawnPos.y += spawnRange - 5f;
					spawnPos.x = transform.position.x + objXAxisSpawnRange;
					cloneAlienShip = (GameObject)Instantiate (alienShip, spawnPos, transform.rotation);

					transform.position = new Vector3 (transform.position.x, transform.position.y + spawnRange, transform.position.z);

					triggerMethod = false;
				} else if (objSpawnChanceRange >= 3 && objSpawnChanceRange <= 6)
				{
					spawnRange = 6f;//spawnrange for ufos on Y axis
					objXAxisSpawnRange = Random.Range (-10, 10);
					spawnPos.y += spawnRange + 5f;
					spawnPos.x = transform.position.x + objXAxisSpawnRange;
					cloneUfoPrefab = (GameObject)Instantiate (ufoPrefab, spawnPos, transform.rotation);

					transform.position = new Vector3 (transform.position.x, transform.position.y + spawnRange, transform.position.z);

					triggerMethod = false;
				} else if (objSpawnChanceRange >= 6 && objSpawnChanceRange <= 10)
				{
					spawnRange = 5f;//spawnrange for flaming meteors on Y axis
					objXAxisSpawnRange = Random.Range (-10, 10);
					spawnPos.y += spawnRange + 5f;
					spawnPos.x = transform.position.x + objXAxisSpawnRange;
					cloneFlamingMet = (GameObject)Instantiate (flamingMetPrefab, spawnPos, transform.rotation);

					transform.position = new Vector3 (transform.position.x, transform.position.y + spawnRange, transform.position.z);

					triggerMethod = false;
				} else
				{
					spawnRange = 8f;//spawnrange for NOTHING
					objXAxisSpawnRange = Random.Range (-10, 10);
					spawnPos.y += spawnRange + 5f;
					spawnPos.x = transform.position.x + objXAxisSpawnRange;

					transform.position = new Vector3 (transform.position.x, transform.position.y + spawnRange, transform.position.z);

					triggerMethod = false;
				}
			} else if (camMovSc.score > 3500)
			{
				//COMPLETELY SPACE OBJECTS!
				objSpawnChanceRange = Random.Range (1, 10);
				if (objSpawnChanceRange > 0 && objSpawnChanceRange <= 3)
				{
					spawnRange = 20f;//spawnrange for alienShips on Y axis
					objXAxisSpawnRange = Random.Range (-10, 10);
					spawnPos.y += spawnRange - 5f;
					spawnPos.x = transform.position.x + objXAxisSpawnRange;
					cloneAlienShip = (GameObject)Instantiate (alienShip, spawnPos, transform.rotation);

					transform.position = new Vector3 (transform.position.x, transform.position.y + spawnRange, transform.position.z);

					triggerMethod = false;
				} else if (objSpawnChanceRange >= 3 && objSpawnChanceRange <= 6)
				{
					spawnRange = 6f;//spawnrange for ufos on Y axis
					objXAxisSpawnRange = Random.Range (-10, 10);
					spawnPos.y += spawnRange + 5f;
					spawnPos.x = transform.position.x + objXAxisSpawnRange;
					cloneUfoPrefab = (GameObject)Instantiate (ufoPrefab, spawnPos, transform.rotation);

					transform.position = new Vector3 (transform.position.x, transform.position.y + spawnRange, transform.position.z);

					triggerMethod = false;
				} else if (objSpawnChanceRange >= 6 && objSpawnChanceRange <= 10)
				{
					spawnRange = 5f;//spawnrange for flaming meteors on Y axis
					objXAxisSpawnRange = Random.Range (-10, 10);
					spawnPos.y += spawnRange + 5f;
					spawnPos.x = transform.position.x + objXAxisSpawnRange;
					cloneFlamingMet = (GameObject)Instantiate (flamingMetPrefab, spawnPos, transform.rotation);

					transform.position = new Vector3 (transform.position.x, transform.position.y + spawnRange, transform.position.z);

					triggerMethod = false;
			}
		}

		if (trigForResources == true) 
		{
			objSpawnChanceRange = Random.Range (0, 500);
			if (objSpawnChanceRange >= 1 && objSpawnChanceRange <= 30)
			{
				objXAxisSpawnRange = Random.Range (-4, 4);
				spawnPos.y += spawnRangeForSpecials + 6.2f;
				spawnPos.x = transform.position.x + objXAxisSpawnRange;
				cloneMetalResource = (GameObject)Instantiate (metalResourcePrefab, spawnPos, transform.rotation);
				trigForResources = false;
			} else if (objSpawnChanceRange > 30 && objSpawnChanceRange <= 60)
			{
				objXAxisSpawnRange = Random.Range (-4, 4);
				spawnPos.y += spawnRangeForSpecials + 6.2f;
				spawnPos.x = transform.position.x + objXAxisSpawnRange;
				cloneTitaniumResource = (GameObject)Instantiate (titaniumResourcePrefab, spawnPos, transform.rotation);
				trigForResources = false;
			} else if (objSpawnChanceRange > 60 && objSpawnChanceRange <= 69)
			{
				// boosterPrefab , cloneBooster

				objXAxisSpawnRange = Random.Range (-4, 4);
				spawnPos.y += spawnRangeForSpecials + 6.25f;
				spawnPos.x = transform.position.x + objXAxisSpawnRange;
				cloneBooster = (GameObject)Instantiate (boosterPrefab, spawnPos, transform.rotation);
				trigForResources = false;
			} else if (objSpawnChanceRange > 69 && objSpawnChanceRange <= 81)
			{
				//shieldPrefab, cloneShield
				objXAxisSpawnRange = Random.Range (-4, 4);
				spawnPos.y += spawnRangeForSpecials + 6.25f;
				spawnPos.x = transform.position.x + objXAxisSpawnRange;
				cloneShield = (GameObject)Instantiate (shieldPrefab , spawnPos, transform.rotation);
				trigForResources = false;
			}
			else
			{
				objXAxisSpawnRange = Random.Range (-4, 4);
				spawnPos.y += spawnRangeForSpecials + 6.2f;
				spawnPos.x = transform.position.x + objXAxisSpawnRange;
				//cloneTitaniumResource = (GameObject)Instantiate (titaniumResourcePrefab , spawnPos, transform.rotation);
				trigForResources = false;
			}
			trigForResources = false;

		}
	}
	}

	public void objSpawnTriggerMethod()
	{
		triggerMethod = true;
		trigForResources = true;
		//transform.position = new Vector3 (transform.position.x, transform.position.y + spawnRange, transform.position.z);
	}


}
