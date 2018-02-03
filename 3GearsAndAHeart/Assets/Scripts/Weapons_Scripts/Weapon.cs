﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour 
{
	public float fireRate = 0;
	public LayerMask whatToHit;

	public Transform BulletTrailPrefab;
	public Transform MuzzleFlashPrefab;

	float timeToSpawnEffect = 0;
	public float effectSpawnRate = 10;
	float timeToFire = 0;
	Transform MilBotFirePoint;


	void Awake ()
	{
		MilBotFirePoint = transform.Find ("MilBotFirePoint");
		if (MilBotFirePoint == null) 
			{
			Debug.LogError ("No MilBotFirePoint? WHAT?!");
			}
	}

	void Update () {
		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				Shoot();
				}
			} 
			else {
			if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
				timeToFire = Time.time + 1 / fireRate;
				Shoot();
				}
			}
	}

	void Shoot() 
	{
		//Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		//Vector2 firePointPosition = new Vector2 (MilBotFirePoint.position.x, MilBotFirePoint.position.y);
	//RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, 100, whatToHit);
		if (Time.time >= timeToSpawnEffect) {
			Effect ();
			timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
		}
			
	}

	void Effect() {
		Instantiate (BulletTrailPrefab, MilBotFirePoint.position, MilBotFirePoint.rotation);
		Transform clone = (Transform) Instantiate (MuzzleFlashPrefab, MilBotFirePoint.position, MilBotFirePoint.rotation);
		clone.parent = MilBotFirePoint;
		float size = Random.Range (1f, 1.5f);
		clone.localScale = new Vector3 (size, size, size);
		Destroy (clone.gameObject, 0.05f);
		}

}