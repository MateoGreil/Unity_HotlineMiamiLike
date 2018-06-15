using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsScript : MonoBehaviour {
	public GameObject	holder;
	public GameObject	bullet;
	public bool 		fireWeapon;
	public int			ammos;
	public float 		power;
	public float 		fireRate;
	
	// Update is called once per frame
	void Update () {
	}

	//Fire bullet if fireWeapon. Else stab
	public void Fire () {
		if (fireWeapon) {
			if (ammos > 0) {
				if (holder.tag == "Player")
					ammos -= 1;
				//Instantiate bullet and play bullet animation
				bullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity, transform);
			}
		}
		else {
			//Animate knife
		}
	}

	/**** FAIRE LA FONCTION POUR LA PERTE DE VIE DU PERSO ****/
}
