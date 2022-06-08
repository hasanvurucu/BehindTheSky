using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOutSky : MonoBehaviour {

	public cameraMovement camMov;
	public bool fadeOutCheck;
//	public float fadeOutTime;

	private bool workOnce = false;

	public SpriteRenderer sprite;

	void Start () {
		fadeOutCheck = false;
//		StartCoroutine (fadeOut (GetComponent<SpriteRenderer> ()), fadeOutCheck);
	}

	void Update()
	{
		if (workOnce == false)
		{
			if (camMov.score > 1000)
			{
				fadeOutCheck = true;
				workOnce = true;
			}
		}
		if (fadeOutCheck == true)
		{
			fadeOutMethod ();
		//	fadeOutTime = 0f;
		//	fadeOutTime += Time.deltaTime;
		}
	}

	void fadeOutMethod()
	{
		Color tmpColor = sprite.color;

		//while (tmpColor.a > 0f)
	//	{
		tmpColor.a -= 0.004f;
		//	sprite.color = tmpColor;

			if (tmpColor.a <= 0f)
			{
				tmpColor.a = 0f;
			}
	//	}
		sprite.color = tmpColor;

	}

	/*	IEnumerator fadeOut (SpriteRenderer _sprite)
	{
		Color tmpColor = _sprite.color;
		while (tmpColor.a > 0f)
		{
			tmpColor.a -= Time.deltaTime / fadeOutTime;
			_sprite.color = tmpColor;
		
			if (tmpColor.a <= 0f)
			{
				tmpColor.a = 0f;
			}
		
			yield return null;
		}
		_sprite.color = tmpColor;
	}*/
}
