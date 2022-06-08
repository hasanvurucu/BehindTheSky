using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienShipScript : MonoBehaviour {

	private float speed;

	private int movementChance;
	private float movementTimer;

	private float shootCooldown;
	public Transform shotSpawnPoint;

	public GameObject shotOfAlien;
	public static GameObject cloneShotOfAlien;

	void Start () {
		speed = 11f;
	}

	void Update () {
		
		if (Input.GetMouseButton (0))
			speed = 11f;
		else
			speed = 11 / 10f;

		Vector3 pos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		pos.y += speed * Time.deltaTime;


		movementTimer += Time.deltaTime;
		if (movementTimer >= 1f) 
		{
			if(movementTimer <= 1.05f)
			{
				movementChance = Random.Range (1, 3);
			}

			if(movementChance == 1)
			{
				pos.x += 3f * Time.deltaTime;
			}
			else if(movementChance == 2)
			{
				pos.x -= 3f * Time.deltaTime;
			}
		}
		if(movementTimer >= 1.7f)
		{
			movementTimer = 0f;
		}

		shootCooldown += Time.deltaTime;
		if (shootCooldown >= 1.4f) 
		{
			cloneShotOfAlien = (GameObject)Instantiate (shotOfAlien, shotSpawnPoint.position, shotSpawnPoint.rotation);
			shootCooldown = 0;
		}


		transform.position = pos;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "objDestroy") 
		{
			Object.Destroy (this.gameObject);
		}
		if(collision.tag == "Player")
		{
			Object.Destroy (this.gameObject);
		}
		//if playershot...
		//playershot explosion...
	}


}
