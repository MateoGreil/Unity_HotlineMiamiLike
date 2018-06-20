using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : PlayerScript {
	Quaternion startingAngle;
    Quaternion stepAngle;

	void Start() {
		weapon = gameObject.transform.GetChild(3).gameObject;
		weapon.transform.position = transform.position;
		weapon.transform.rotation = transform.rotation;
		weapon.transform.Translate(new Vector3(-0.125f, -0.21f, 0));
		weapon.GetComponent<SpriteRenderer>().sortingLayerName = "EquipedWeapon";
		weapon.GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<WeaponsScript>().attachedSprite;
		weapon.GetComponent<BoxCollider2D>().enabled = false;
		startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
    	stepAngle = Quaternion.AngleAxis(5, Vector3.up);
	}

	void Update() {
		startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
    	stepAngle = Quaternion.AngleAxis(5, Vector3.up);
		Watch();
	}

	void Watch() {
		RaycastHit hit;
    	Quaternion angle = transform.rotation * startingAngle;
        Vector3 direction = angle * Vector3.forward;
        Vector3 pos = transform.position;
        for (int i = 0; i < 24; i++) {
            if (Physics.Raycast(pos, direction, out hit, 500)) {
            	if (hit.collider.gameObject == GameManager.instance.player) {
					Debug.Log("Je t'ai vu !");
				}
				else {Debug.Log("Je t'ai pas vu...");}
      		}
    		direction = stepAngle * direction;
		}
	}
}