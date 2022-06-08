using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objSpawnCollider : MonoBehaviour {

	public objSpawnTrigScript objSpawn;

	void Start () {
		
	}

	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "objSpawnTrigger") 
		{
			objSpawn.objSpawnTriggerMethod ();
		}
	}
}
