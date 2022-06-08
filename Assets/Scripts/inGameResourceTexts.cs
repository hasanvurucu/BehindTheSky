using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inGameResourceTexts : MonoBehaviour {

	public static int metalResource;
	public static int titaniumResource;

	public Text metalResourceText;
	public Text titaniumResourceText;

	void Start () 
	{
		metalResource = PlayerPrefs.GetInt ("TheMetalResource", metalResource);
		titaniumResource = PlayerPrefs.GetInt ("TheTitaniumResource", titaniumResource);
	}

	void Update () 
	{
		inGameSetMetalResourceText ();
		inGameSetTitaniumResourceText ();

		metalResource = PlayerPrefs.GetInt ("TheMetalResource", metalResource);
		titaniumResource = PlayerPrefs.GetInt ("TheTitaniumResource", titaniumResource);
		//PlayerPrefs.SetInt ("TheMetalResource", metalResource);
		//PlayerPrefs.SetInt ("TheTitaniumResource", titaniumResource);
	}

	public void inGameSetMetalResourceText()
	{
		metalResourceText.text = "  x " + metalResource.ToString ();
	}

	public void inGameSetTitaniumResourceText()
	{
		titaniumResourceText.text = "  x " + titaniumResource.ToString ();
	}
}
