using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public float speed;
	GameObject weapon;

	// Use this for initialization
	void Start () {
		weapon = gameObject.transform.GetChild(2).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetKeyMove())
			Move();
		Rotate();
		/*if (Input.GetKey(KeyCode.Mouse0))
			weapon.GetComponent<WeaponsScript>().Fire();*/
		if (Input.GetKeyDown(KeyCode.Mouse1) && weapon != null)
			DropWeapon();
	}

	// GetKeyMove return true if a key of movement is down
	bool GetKeyMove() {
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
		Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
			return (true);
		return (false);
	}

	// Move move the character in the world
	void Move() {
		// Move UP
		if (Input.GetKey(KeyCode.W)) {
			//Move UP & RIGHT
			if (Input.GetKey(KeyCode.D))
				gameObject.transform.position += (new Vector3(0.5f, 0.5f, 0).normalized * speed * Time.deltaTime);
			//Move UP & LEFT
			else if (Input.GetKey(KeyCode.A))
				gameObject.transform.position += (new Vector3(-0.5f, 0.5f, 0).normalized * speed * Time.deltaTime);
			else
				gameObject.transform.position += (new Vector3(0, 1, 0).normalized * speed * Time.deltaTime);
		}
		// Move DOWN
		else if (Input.GetKey(KeyCode.S)) {
			//Move DOWN & RIGHT
			if (Input.GetKey(KeyCode.D))
				gameObject.transform.position += (new Vector3(0.5f, -0.5f, 0).normalized * speed * Time.deltaTime);
			//Move DOWN & LEFT
			else if (Input.GetKey(KeyCode.A))
				gameObject.transform.position += (new Vector3(-0.5f, -0.5f, 0).normalized * speed * Time.deltaTime);
			else
				gameObject.transform.position += (new Vector3(0, -1, 0).normalized * speed * Time.deltaTime);
		}
		// Move RIGHT
		else if (Input.GetKey(KeyCode.D))
			gameObject.transform.position += (new Vector3(1, 0, 0).normalized * speed * Time.deltaTime);
		// Move LEFT
		else
			gameObject.transform.position += (new Vector3(-1, 0, 0).normalized * speed * Time.deltaTime);
		Camera.main.transform.position = transform.position - new Vector3(0, 0, 10);
	}

	// Rotate make the character look at the mouse
	void Rotate() {
		Vector3 mousePosition;
		Vector3 dir;
		float angle;

		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = transform.position.z;
		dir = mousePosition - transform.position;
 		angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
 		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

	//DropWeapon, obviously, it transform the player in a candle
	void DropWeapon() {
		weapon.transform.Translate(new Vector3(0, -1, 0));
		weapon.GetComponent<BoxCollider2D>().enabled = true;
		weapon.GetComponent<SpriteRenderer>().sortingLayerName = "Weapon";
		weapon.transform.parent = null;
		weapon = null;
	}

	void OnTriggerStay2D(Collider2D collider) {
		//Take the weapon
		if (collider.tag == "Weapon" && weapon == null && Input.GetKey(KeyCode.E)) {
			weapon = collider.gameObject;
			weapon.transform.parent = gameObject.transform;
			weapon.transform.position = transform.position;
			weapon.transform.rotation = transform.rotation;
			weapon.transform.Translate(new Vector3(-0.125f, -0.21f, 0));
			weapon.GetComponent<BoxCollider2D>().enabled = false;
			weapon.GetComponent<SpriteRenderer>().sortingLayerName = "EquipedWeapon";
		}
	}
}
