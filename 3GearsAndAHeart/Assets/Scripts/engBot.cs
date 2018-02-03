using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engBot : MonoBehaviour {

	[System.Serializable]
	public class EngBotStats 
	{
	public int Health = 100;
	}
	public EngBotStats engBotStats = new EngBotStats ();
	public int fallBoundary = -15;

	void Update () 
	{
		if (transform.position.y <= fallBoundary) 
			{
			Debug.Log ("Suppose to be dead!");
			DamageEngBot (9999999);
			}
	}

	public void DamageEngBot (int damage) 
	{
		engBotStats.Health -= damage;
		if (engBotStats.Health <= 0) {
			GameMaster.KillEngBot(this);
		}
	}


}
