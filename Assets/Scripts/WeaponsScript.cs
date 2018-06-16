using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsScript : MonoBehaviour {
	public GameObject	bullet;
	public bool 		fireWeapon;
	public int			ammos;
	public float 		power;
	public float 		fireRate;
	public Sprite 		attachedSprite;
	public Sprite 		onGroundSprite;
	
	private SpriteRenderer spriteRenderer;

	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	//Fire bullet if fireWeapon. Else stab
	public void Fire () {
		if (fireWeapon) {
			if (ammos > 0) {
				if (transform.parent.tag == "Player")
					ammos -= 1;
				//Instantiate bullet and play bullet animation
				bullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity, transform);
			}
		}
		else {
			//Animate knife
		}
	}

	//Change weapon's sprite when picked up
	public void GetWeaponSprite () {
		if (transform.parent)
			spriteRenderer.sprite = attachedSprite;
		else
			spriteRenderer.sprite = onGroundSprite;		
	}
	

	/**** FAIRE LA FONCTION POUR LA PERTE DE VIE DU PERSO ****/
}
