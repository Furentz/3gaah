using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone: MonoBehaviour {
	

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "MilBot") {
			//Execute this code if the colliding object is the player, to access the player gameObject, use coll.
			coll.gameObject.GetComponent<milBot> ().DamageMilBot (999999);
			Debug.Log ("MilBot Suppose to be dead!");
		}

			if (coll.gameObject.tag == "SciBot") {
				//Execute this code if the colliding object is the player, to access the player gameObject, use coll.
				coll.gameObject.GetComponent<sciBot> ().DamageSciBot (999999);
				Debug.Log ("SciBot Suppose to be dead!");
			}

				if (coll.gameObject.tag == "EngBot") {
					//Execute this code if the colliding object is the player, to access the player gameObject, use coll.
					coll.gameObject.GetComponent<engBot> ().DamageEngBot (999999);
					Debug.Log ("EngBot Suppose to be dead!");
				}

					if (coll.gameObject.tag == "Enemy") {
						//Execute this code if the colliding object is the player, to access the player gameObject, use coll.
						coll.gameObject.GetComponent<MobDamage> ().DamageEnemy (999999);
						Debug.Log ("Suppose to be dead!");
				

						
		}
	}
}