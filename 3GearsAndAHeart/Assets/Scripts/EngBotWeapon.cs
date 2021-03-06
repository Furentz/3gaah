using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngBotWeapon : MonoBehaviour 
{
	public float fireRate = 0;
	public float Damage = 10;

	public Transform BulletTrailPrefab;
	Transform EngBotFirePoint;


	void Update () 
	{
			if (Input.GetButtonDown ("Fire2")) 
			{
				var mousePos = Input.mousePosition;
				mousePos.z = 10;       // we want 0m away from the camera position
				var objectPos = Camera.main.ScreenToWorldPoint(mousePos);
				Instantiate(BulletTrailPrefab, objectPos, Quaternion.identity);
				
			//Removes nano from the nanocell bar
			GameObject.Find ("HUD").GetComponent<UserInterface>().RemoveNano(10);

			}
	}

}
