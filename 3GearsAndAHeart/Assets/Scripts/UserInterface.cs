using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UserInterface : MonoBehaviour {

	public Image NanoBar;
	public float NanoCell = 100;
	public Text TxtNanoBar;

	public void RemoveNano(float val)
	{
		NanoCell -= val;
		NanoCell = Mathf.Clamp (NanoCell, 0, 100);
		NanoBar.fillAmount = NanoCell / 100;
		TxtNanoBar.text = NanoCell + " %";
	}
		

}
