using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class howToPlayManagement : MonoBehaviour {

	public Text nextPreviousText;

	public GameObject htp1;
	public GameObject htp2;

	private bool htp1Boolean;

	void Start () {
		nextPreviousText.text = "NEXT";
		htp1.SetActive (true);
		htp2.SetActive (false);
		htp1Boolean = true;
	}

	void Update () {
		
	}

	public void nextAndPrevious()
	{
		if (htp1Boolean == true)
		{
			htp1.SetActive (false);
			htp2.SetActive (true);
			htp1Boolean = false;
			nextPreviousText.text = "PREVIOUS";
		} else
		{
			htp1.SetActive (true);
			htp2.SetActive (false);
			htp1Boolean = true;
			nextPreviousText.text = "NEXT";
		}
	}
}
