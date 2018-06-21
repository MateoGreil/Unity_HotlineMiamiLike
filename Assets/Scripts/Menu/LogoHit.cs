using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoHit : MonoBehaviour {

	private AudioSource		audio;
	private Vector3			selectPos;
	private RaycastHit2D		hit;
	private Vector3 originPosition;
	private Quaternion originRotation;

	public float shake_decay = 0.1f;
	public float shake_intensity = .3f;

	private float temp_shake_intensity = 0;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0)) {
			selectPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(selectPos.x, selectPos.y);
			if (hit = Physics2D.Raycast(mousePos2D, Vector2.zero))
			{
				if (hit.collider != null) {
					audio.Play();
					Shake ();
				}
				else
					Debug.Log ("This isn't a Player");
			}
		}

		if (temp_shake_intensity > 0){
			transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
			transform.rotation = new Quaternion(
				originRotation.x + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f,
				originRotation.y + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f,
				originRotation.z + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f,
				originRotation.w + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f);
			temp_shake_intensity -= shake_decay;
		}
		
	}

	void Shake(){
		originPosition = transform.position;
		originRotation = transform.rotation;
		temp_shake_intensity = shake_intensity;

	}
}
