using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameOverRevivir : MonoBehaviour {

	void Update() {
		if (Input.GetButtonUp ("Fire") || Input.GetButtonDown("Start")) SceneManager.LoadScene("Menu");
	}

}
