using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameEscapeButton : MonoBehaviour {

	public buttonScript buttonSc;

	void Update () 
	{
		if (Input.GetKeyUp (KeyCode.Escape))
		{
			buttonSc.pauseButtonMethod ();
		}
	}
}
