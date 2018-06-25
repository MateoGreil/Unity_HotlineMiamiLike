using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsActions : MonoBehaviour {

	public void LoadLevel () {
		SceneManager.LoadScene("Level0");
	}

	public void ExitGame() {
		Application.Quit();
	}
}
