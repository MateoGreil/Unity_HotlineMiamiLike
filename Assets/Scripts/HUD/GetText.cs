using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetText : MonoBehaviour {
	public Text 	ammosText;
	public PlayerScript	playerScript;
	
	// Update is called once per frame
	void Update () {
		if (playerScript.weapon != null)
			ammosText.text = playerScript.weapon.GetComponent<WeaponsScript>().ammos.ToString();
		else
			ammosText.text = "0";
	}
}
