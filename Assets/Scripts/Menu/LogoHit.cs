using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoHit : MonoBehaviour {

	private AudioSource		audio;
	private Vector3			selectPos;
	private RaycastHit2D		hit;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetMouseButtonDown(0)) {
			selectPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(selectPos.x, selectPos.y);
			if (hit = Physics2D.Raycast(mousePos2D, Vector2.zero))
			{
				if (hit.collider != null)
					audio.Play();
				else
					Debug.Log ("This isn't a Player");
			}
		}
		*/
		Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit=Physics2D.Raycast(rayPos, Vector2.zero, 0f);
         
         if (hit)
         {
              Debug.Log(hit.transform.name);
        }
	}
}
