using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	public bool NpcEnterZone = false;

	void OnTriggerEnter2D(Collider2D other)
	{
		NpcEnterZone = true;
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.E)) {
			if (NpcEnterZone == true) {
				
				Debug.LogError ("J'ai appuyer sur E et le jeu l'a enregistré");
				FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
			}
		}
	}


}
