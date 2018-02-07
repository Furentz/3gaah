using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilBotMoveSnd : MonoBehaviour {

	public AudioClip SoundMilBotMove;
	private AudioSource Audio;
	public float PitchMin=0.9f;
	public float PitchMax=1.3f;
	public float VolMin=0.8f,VolMax=1.2f;


	// Use this for initialization
	void Start () {
		Audio = GetComponent<AudioSource> ();


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal3") != 0) {
			if (!Audio.isPlaying) 
				{
				Audio.pitch = Random.Range (PitchMin, PitchMax);
				Audio.volume = Random.Range (VolMin, VolMax);
				Audio.PlayOneShot (SoundMilBotMove);
				}

			}
	}
}
