using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTrail : MonoBehaviour {
	public int moveSpeed = 10;
	public int BulletDmg = 50;
	//public MobDamage other;

	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
		Destroy (gameObject, 2);
	}
		

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy") {
			coll.gameObject.GetComponent<MobDamage> ().DamageEnemy (BulletDmg);
			Destroy (gameObject, 0);
		}
	}

		
}
