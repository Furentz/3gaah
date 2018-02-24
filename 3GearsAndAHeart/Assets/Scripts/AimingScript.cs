using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AimingScript : MonoBehaviour {

	public float speed = 5f;
	public Transform target;
	public float nextTimeToSearch;

	void Update () 
	{
			if (target == null) 
			{
			FindPlayer ();
			return;
			}

	Vector2 direction = target.position - transform.position;
	float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
	Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	transform.rotation = Quaternion.Slerp (transform.rotation, rotation, speed * Time.deltaTime);
	}
	

	void FindPlayer()
	{
			if (nextTimeToSearch <= Time.time) 
			{
			GameObject searchResult2 = GameObject.FindGameObjectWithTag ("MilBot");
				if (searchResult2 != null)
				target = searchResult2.transform;
			}
	}


	
}
