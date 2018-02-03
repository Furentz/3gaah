using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sciBot : MonoBehaviour {

	[System.Serializable]
	public class SciBotStats 
	{
	public int Health = 100;
	}
	public SciBotStats sciBotStats = new SciBotStats ();
	public int fallBoundary = -15;

	void Update () 
	{
		if (transform.position.y <= fallBoundary) 
			{
			Debug.Log ("Suppose to be dead!");
			DamageSciBot (9999999);
			}
	}

	public void DamageSciBot (int damage) 
	{
		sciBotStats.Health -= damage;
		if (sciBotStats.Health <= 0) {
			GameMaster.KillSciBot(this);
		}
	}


}
