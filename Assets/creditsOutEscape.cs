using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditsOutEscape : MonoBehaviour {

	public GameObject creditsPanel;

	void Update () {

		if (Input.GetKeyUp (KeyCode.Escape) || Input.GetMouseButtonDown(0))
		{
			creditsPanel.SetActive (false);
		}
	}
}
