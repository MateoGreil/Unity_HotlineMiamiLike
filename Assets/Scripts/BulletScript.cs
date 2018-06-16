using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	public float 	speed;

	//private Vector3 direction;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//make bullet go in player direction
		transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);

		//If hits someone destroy bullet
	}
}
