using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager gm;
	public GameObject player;
	
	void Awake() {
		if (gm == null)
			gm = this;
	}
}
