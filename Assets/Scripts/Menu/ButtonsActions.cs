using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsActions : MonoBehaviour {

	public void LoadLevel () {
		SceneManager.LoadScene("backup");
	}

	public void ExitGame() {
		Application.Quit();
	}
}
