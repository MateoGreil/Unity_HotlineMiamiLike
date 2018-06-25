using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDScript : MonoBehaviour {
	private static bool created = false;

	// Use this for initialization

	/* De-comment to load HUD on every levels */

	// void Awake () {
	// 	//Create HUD if not already
	// 	if (!created) {
	// 		DontDestroyOnLoad(this.gameObject);
    //         created = true;
    //         //Debug.Log("Awake: " + this.gameObject);
    //     }
	// }
}
