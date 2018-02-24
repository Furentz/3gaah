using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class milBot : MonoBehaviour {

	public int fallBoundary = -15;
	public static int NanoPool = 50;
	public float Health = 100f;



	void Update () 
	{
		if (transform.position.y <= fallBoundary) 
			{
			Debug.Log ("Suppose to be dead!");
			DamageMilBot (9999999);
			}
	}

	public void DamageMilBot (float Damage) 
	{
		Health -= Damage;
		if (Health <= 0) {
			GameMaster.KillMilBot(this);
		}
	}


}
