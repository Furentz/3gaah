using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobDamage : MonoBehaviour 
{

	[System.Serializable]
	public class EnemyStats 
	{
	public int Health = 100;
	}
	public EnemyStats enemyStats = new EnemyStats ();
	public int fallBoundary = -15;
	public int time2die = 100;
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
			StartCoroutine(WaitSeconds());
			}
	}
		
	IEnumerator WaitSeconds()
	{
		yield return (time2die);
		Debug.LogError ("Wait for seconds?");
		GameMaster.KillEnemy(this);
	}


}
