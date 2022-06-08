using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resourceTextManage : MonoBehaviour {

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
		metalResource = PlayerPrefs.GetInt ("TheMetalResource", metalResource);
		titaniumResource = PlayerPrefs.GetInt ("TheTitaniumResource", titaniumResource);

		PlayerPrefs.SetInt ("TheMetalResource", metalResource);
		PlayerPrefs.SetInt ("TheTitaniumResource", titaniumResource);

		SetMetalResourceText ();
		SetTitaniumResourceText ();
	}

	public void SetMetalResourceText()
	{
		metalResourceText.text = "  x " + metalResource.ToString ();
	}

	public void SetTitaniumResourceText()
	{
		titaniumResourceText.text = "  x " + titaniumResource.ToString ();
	}
}
