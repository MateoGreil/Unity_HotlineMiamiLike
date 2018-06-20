using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsScript : MonoBehaviour {
	public GameObject	bullet;
	public bool 		fireWeapon;
	public int			ammos;
	public float 		fireRate;
	public Sprite 		attachedSprite;
	public Sprite 		onGroundSprite;
	private GameObject	newBullet;
	private float		deltaTime;
	
	private SpriteRenderer spriteRenderer;

	void Start () {
		deltaTime = fireRate;
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		deltaTime += Time.deltaTime;
	}

	//Fire bullet if fireWeapon. Else stab
	public void Fire () {
		if (fireWeapon && deltaTime > fireRate && ammos > 0) {
			deltaTime = 0;
			if (transform.parent.tag == "Player")
				ammos -= 1;
			//Instantiate bullet and play bullet animation
			newBullet = Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
			newBullet.transform.Rotate(Vector3.forward * -90);
			newBullet.transform.Translate(0.5f, 0, 0);
		}
	}

	//Change weapon's sprite when picked up
	public void GetWeaponSprite () {
		if (spriteRenderer.sprite == attachedSprite)
			spriteRenderer.sprite = onGroundSprite;
		else
			spriteRenderer.sprite = attachedSprite;
	}

	void OnTriggerStay2D(Collider2D collider) {
		if (collider.tag == "Enemy" && Input.GetKey(KeyCode.Mouse0)) {
			Destroy(collider.gameObject);
		}
	}
}
