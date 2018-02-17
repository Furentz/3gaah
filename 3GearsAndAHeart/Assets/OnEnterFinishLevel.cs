using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEnterFinishLevel : MonoBehaviour {


	Animator Anim;
	public string LevelToLoad;
	public AudioClip SoundWin;

	void Start(){
	
		Anim = GetComponent<Animator> ();
	}


	// What Will happen when something enters this zone
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "MilBot") {
			Anim.SetTrigger ("win");
			GetComponent<AudioSource> ().PlayOneShot (SoundWin);
		}

	}


	void LoadLevel()
	{
		SceneManager.LoadScene (LevelToLoad);
	}


}
