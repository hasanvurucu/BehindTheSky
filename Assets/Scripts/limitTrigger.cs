using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitTrigger : MonoBehaviour {

	void Start () {
		
	}


	void Update () {

	}

	public void triggerMethod()
	{
			transform.position = new Vector3 (transform.position.x, transform.position.y + 480f, transform.position.z);
	}
}
