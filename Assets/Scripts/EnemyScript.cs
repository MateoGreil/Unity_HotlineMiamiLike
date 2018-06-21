using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : PlayerScript {

	void Start() {
		weapon = gameObject.transform.GetChild(3).gameObject;
		weapon.transform.position = transform.position;
		weapon.transform.rotation = transform.rotation;
		weapon.transform.Translate(new Vector3(-0.125f, -0.21f, 0));
		weapon.GetComponent<SpriteRenderer>().sortingLayerName = "EquipedWeapon";
		weapon.GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<WeaponsScript>().attachedSprite;
		weapon.GetComponent<BoxCollider2D>().enabled = false;
	}

	void Update() {
		Watch();
	}

	void Watch() {
		int i;
		RaycastHit2D hit;
		Vector3 direction;

		direction = Quaternion.AngleAxis(-60, Vector3.forward) * (-transform.up);
		i = 0;
		while (i < 24) {
			Debug.Log("direction = ");
			Debug.Log(direction);
        	hit = Physics2D.Raycast(transform.position - transform.up * 0.5f, direction, 10);
       		if (hit && hit.collider.tag == "Player") {
				Debug.DrawRay(transform.position - transform.up * 0.5f, direction * 10, Color.green);
			}
			else
				Debug.DrawRay(transform.position - transform.up * 0.5f, direction * 10, Color.red);
			i++;
			direction = Quaternion.AngleAxis(5, Vector3.forward) * direction;
		}
	}
}