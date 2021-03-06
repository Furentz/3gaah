using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNme : MonoBehaviour 
{
	//Reference vers prefab de projectile
	public Transform AmmoPrefab;

	//Reference a transform
	private Transform ThisTransform;

	private float FireRate = 1f;


	void Awake ()
	{
		ThisTransform = transform.Find ("ATFirePoint");
	}

	void Start()
	{
		FireAmmo ();
	}

	public void FireAmmo()
	{
	Instantiate (AmmoPrefab, ThisTransform.position, ThisTransform.rotation);
	//FireRate
		Invoke("FireAmmo", FireRate);
	}


}
