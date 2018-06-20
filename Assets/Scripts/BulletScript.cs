using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	public float 	speed;
	Vector3  startingPoint;
	public float	distBullet;

	//private Vector3 direction;
	// Use this for initialization
	void Start () {
		startingPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//make bullet go in player direction
		transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
		//TO-DO : Destroy bullet if collides with something or until certain amount of time
		if (Vector3.Distance(startingPoint, transform.position) >= distBullet)
			Destroy(this.gameObject);
		
	}

	 void OnCollisionEnter2D(Collision2D collision) {
		 Destroy(this.gameObject);
	 }
}
