using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour 
{

	[System.Serializable]
	public class TurretStats 
	{
	public int Health = 200;
	}

	public TurretStats enemyStats = new TurretStats ();
	public int fallBoundary = -15;
	Animator anim;

	void Start(){
		anim = GetComponent<Animator>();
	}


	void Update () 
	{
		if (transform.position.y <= fallBoundary) 
		{
			DamageEnemy (9999999);
		}
	}

	public void DamageEnemy (int damage) 
	{
		enemyStats.Health -= damage;
		if (enemyStats.Health <= 0) {
			anim.SetTrigger ("dead");

			//GameMaster.KillEnemy(this);
		}
	}



}
