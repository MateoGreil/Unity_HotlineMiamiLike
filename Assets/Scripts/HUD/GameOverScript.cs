using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour {
	public PlayerScript player;
	public GameObject gameOver;

	void Start() {
		gameOver.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (player.isDead) {
			gameOver.SetActive(true);
		}	
	}
}
