using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class milBot : MonoBehaviour {

	public int fallBoundary = -15;
	public static int NanoPool = 50;
	public static int Health = 100;



	void Update () 
	{
		if (transform.position.y <= fallBoundary) 
			{
			Debug.Log ("Suppose to be dead!");
			DamageMilBot (9999999);
			}
	}

	public void DamageMilBot (int damage) 
	{
		Health -= damage;
		if (Health <= 0) {
			GameMaster.KillMilBot(this);
		}
	}


}
