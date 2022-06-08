using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceManageScript : MonoBehaviour {
	
	public static int metalResource;
	public static int titaniumResource;
	public static int playerGold;

	void Start () 
	{
		metalResource = PlayerPrefs.GetInt ("TheMetalResource", metalResource);
		titaniumResource = PlayerPrefs.GetInt ("TheTitaniumResource", titaniumResource);
		playerGold = PlayerPrefs.GetInt ("ThePlayerGold", playerGold);
	}

	void Update () 
	{
		PlayerPrefs.SetInt ("TheMetalResource", metalResource);
		PlayerPrefs.SetInt ("TheTitaniumResource", titaniumResource);
		PlayerPrefs.SetInt ("ThePlayerGold", playerGold);

		metalResource = PlayerPrefs.GetInt ("TheMetalResource", metalResource);
		titaniumResource = PlayerPrefs.GetInt ("TheTitaniumResource", titaniumResource);
		playerGold = PlayerPrefs.GetInt ("ThePlayerGold", playerGold);
	}

	public void metalResourceIncrease()
	{
		metalResource++;
		PlayerPrefs.SetInt ("TheMetalResource", metalResource);
	}
	public void titaniumResourceIncrease()
	{
		titaniumResource++;
		PlayerPrefs.SetInt ("TheTitaniumResource", titaniumResource);
	}
	public void metalResourceDecrease()
	{
		metalResource--;
		PlayerPrefs.SetInt ("TheMetalResource", metalResource);
	}
	public void titaniumResourceDecrease()
	{
		titaniumResource--;
		PlayerPrefs.SetInt ("TheTitaniumResource", titaniumResource);
	}
}
