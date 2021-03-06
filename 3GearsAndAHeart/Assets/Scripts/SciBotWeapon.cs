using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SciBotWeapon : MonoBehaviour 
{
	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask whatToHit;

	public Transform BulletTrailPrefab;
	public Transform MuzzleFlashPrefab;

	float timeToSpawnEffect = 0;
	public float effectSpawnRate = 10;
	float timeToFire = 0;
	Transform SciBotFirePoint;


	void Awake ()
	{
		SciBotFirePoint = transform.Find ("SciBotFirePoint");
		if (SciBotFirePoint == null) 
			{
			Debug.LogError ("No SciBotFirePoint? WHAT?!");
			}
	}

	void Update () {
		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire3")) {
				Shoot();
				}
			} 
			else {
			if (Input.GetButton ("Fire3") && Time.time > timeToFire) {
				timeToFire = Time.time + 1 / fireRate;
				Shoot();
				}
			}
	}

	void Shoot() 
	{
		Debug.Log ("Test");	
	Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2 (SciBotFirePoint.position.x, SciBotFirePoint.position.y);
	RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, 100, whatToHit);
		if (Time.time >= timeToSpawnEffect) {
			Effect ();
			timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
		}

	Debug.DrawLine (firePointPosition, (mousePosition-firePointPosition)*100, Color.cyan);
		if (hit.collider != null) 
			{
			Debug.DrawLine (firePointPosition, hit.point, Color.red);
			Debug.Log ("We hit " + hit.collider.name + "and did " + Damage + " damage.");
			}
	}

	void Effect() {
		Instantiate (BulletTrailPrefab, SciBotFirePoint.position, SciBotFirePoint.rotation);
		Transform clone = (Transform) Instantiate (MuzzleFlashPrefab, SciBotFirePoint.position, SciBotFirePoint.rotation);
		clone.parent = SciBotFirePoint;
		float size = Random.Range (1f, 1.5f);
		clone.localScale = new Vector3 (size, size, size);
		Destroy (clone.gameObject, 0.05f);
		}

}
