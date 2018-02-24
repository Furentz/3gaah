using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NmeBulletMove : MonoBehaviour {

	public float maxSpeed = 5f;
	public float LifeTime = 1f;
	public int Damage = 25;

	// Update is called once per frame

	void Start()
	{
		Invoke ("Die", LifeTime);
	}

	void Update ()
	{

		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (maxSpeed * Time.deltaTime, 0, 0);
		pos += transform.rotation * velocity;
		transform.position = pos;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "MilBot") 
			{
			other.gameObject.GetComponent<milBot> ().DamageMilBot(Damage);
			Destroy (gameObject, 0);
			}
	}


	public void Die()
		{
			Destroy(gameObject);
		}



}
