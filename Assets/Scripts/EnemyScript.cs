using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : PlayerScript {
	public float rotationSpeed;
	public float timeToResetFocus;
	float countdown;
	GameObject focus;

	void Start() {
		countdown = 0;
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
		if (focus) {
			gameObject.GetComponent<FollowPath>().enabled = false;
			if (Vector3.Distance(focus.transform.position, transform.position) > 5)
				gameObject.transform.Translate(new Vector3(0f, -1f, 0f).normalized * speed * Time.deltaTime);
			FocusOn(focus);
			weapon.GetComponent<WeaponsScript>().Fire();
		}
		else
			gameObject.GetComponent<FollowPath>().enabled = true;
	}

	//Watch detect if the player is in the FOV of the enemy
	void Watch() {
		int i;
		RaycastHit2D hit;
		Vector3 direction;
		GameObject resetFocus;

		resetFocus = null;
		direction = Quaternion.AngleAxis(-60, Vector3.forward) * (-transform.up);
		i = 0;
		while (i < 24) {
        	hit = Physics2D.Raycast(transform.position /*- transform.up * 0.5f*/, direction, 10);
       		if (hit && hit.collider.tag == "Player") {
				resetFocus = hit.collider.gameObject;
				Debug.DrawRay(transform.position /*- transform.up * 0.5f*/, direction * 10, Color.green);
			}
			else
				Debug.DrawRay(transform.position /*- transform.up * 0.5f*/, direction * 10, Color.red);
			i++;
			direction = Quaternion.AngleAxis(5, Vector3.forward) * direction;
		}
		if (!resetFocus) {
			countdown += Time.deltaTime;
			if (countdown > timeToResetFocus) {
				focus = resetFocus;
				countdown = 0;
			}
		}
		else
			focus = resetFocus;
	}

	//FocusOn rotate the enemy to shot the player
	void FocusOn(GameObject focus) {
        Vector3 targetPoint;
        Quaternion targetRotation;
 
		targetPoint = (focus.transform.position - transform.position).normalized;
        targetRotation = Quaternion.LookRotation(targetPoint, -transform.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
		transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, transform.rotation.eulerAngles.z));
	}

	void OnTriggerStay2D(Collider2D collider) {
		if (focus == null && collider.tag == "Player") {
			focus = collider.gameObject;
		}
	}

}