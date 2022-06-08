using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudScript : MonoBehaviour {

	private float speed;

	void Start () {

		speed = Random.Range (-3f, 3f);

		//randomspawn komutu - atmosfer sınırları içinde - integer ile belirle ki iç içe bulutlar oluşmasın.
		//ekranın solundan çıkarsa sağdan geri girişi, sağdan çıkarsa soldan geri girişi sağlayan komut.

	}
		
	void Update () {

		Vector2 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.tag == "hitableLimit") 
		{
			speed = -speed;
		}
		if (collision.tag == "objDestroy") 
		{
			Object.Destroy (this.gameObject);
		}

	}

}
