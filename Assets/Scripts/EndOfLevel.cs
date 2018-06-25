using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour {
	GameObject[] enemy;
 
	void Awake() {
	}

	void Update()
    {
		enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy.Length == 0) {
        	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
    }
}
