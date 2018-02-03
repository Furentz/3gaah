using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;

	void Start() {
		if (gm == null) {
			gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
		}
	}

	public Transform MilBotPrefab;
	public Transform EngBotPrefab;
	public Transform SciBotPrefab;
	public Transform SpawnPoint;
	public float spawnDelay = 2;
	public Transform spawnPrefab;

	public IEnumerator RespawnMilBot () {
		Debug.Log ("TODO: Add waiting for spawn sound");
		yield return new WaitForSeconds (spawnDelay);

		Instantiate (MilBotPrefab, SpawnPoint.position, SpawnPoint.rotation);
		Transform clone = Instantiate(spawnPrefab, SpawnPoint.position, SpawnPoint.rotation);
		Destroy (clone.gameObject, 5f);
	}

	public IEnumerator RespawnEngBot () {
		Debug.Log ("TODO: Add waiting for spawn sound");
		yield return new WaitForSeconds (spawnDelay);

		Instantiate (EngBotPrefab, SpawnPoint.position, SpawnPoint.rotation);
		Transform clone = Instantiate(spawnPrefab, SpawnPoint.position, SpawnPoint.rotation);
		Destroy (clone.gameObject, 5f);
	}

	public IEnumerator RespawnSciBot () {
		Debug.Log ("TODO: Add waiting for spawn sound");
		yield return new WaitForSeconds (spawnDelay);

		Instantiate (SciBotPrefab, SpawnPoint.position, SpawnPoint.rotation);
		Transform clone = Instantiate(spawnPrefab, SpawnPoint.position, SpawnPoint.rotation);
		Destroy (clone.gameObject, 5f);
	}

	public static void KillMilBot (milBot player) {
		Destroy (player.gameObject);
		gm.StartCoroutine (gm.RespawnMilBot());
	}

	public static void KillEngBot (engBot player2) {
		Destroy (player2.gameObject);
		gm.StartCoroutine (gm.RespawnEngBot());
	}

	public static void KillSciBot (sciBot player3) {
		Destroy (player3.gameObject);
		gm.StartCoroutine (gm.RespawnSciBot());
	}

	public static void KillEnemy (MobDamage enemy){
		Destroy (enemy.gameObject);
	
	}

	public static void KillEnemy (TurretControl enemy){
		Destroy (enemy.gameObject);

	}


}
