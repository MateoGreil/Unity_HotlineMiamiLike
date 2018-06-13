using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetKeyMove())
			Move();
		Rotate();
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
		if (Input.GetKey(KeyCode.W))
			gameObject.transform.position += (new Vector3(0, speed, 0) * Time.deltaTime);
		// Move LEFT
		if (Input.GetKey(KeyCode.A))
			gameObject.transform.position += (new Vector3(-speed, 0, 0) * Time.deltaTime);
		// Move RIGHT
		if (Input.GetKey(KeyCode.D))
			gameObject.transform.position += (new Vector3(speed, 0, 0) * Time.deltaTime);
		// Move DOWN
		if (Input.GetKey(KeyCode.S))
			gameObject.transform.position += (new Vector3(0, -speed, 0) * Time.deltaTime);
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
}
