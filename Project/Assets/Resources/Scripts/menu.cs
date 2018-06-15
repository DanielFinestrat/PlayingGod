using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

	private GameObject start;
	private GameObject exit;

	private bool canMove = true;
	private bool somethingSelected = false;

	private int index = 0;

	public AudioClip cambioMenu;
	public AudioClip seleccionMenu;
	private AudioSource miAudio;

	void Start () {
		miAudio = GetComponent<AudioSource>();
		start = transform.Find ("start").gameObject;
		exit = transform.Find ("exit").gameObject;
		start.transform.localScale = new Vector3(start.transform.localScale.x * 1.3f, start.transform.localScale.y * 1.3f, start.transform.localScale.z);
	}

	void Update () {
		moverCursor ();
		seleccion ();
	}

	void seleccion(){
		if ((Input.GetButtonDown("Fire") || Input.GetButtonDown("Start")) && !somethingSelected) {
			canMove = false;
			somethingSelected = true;
			miAudio.clip = seleccionMenu;
			miAudio.Play();
			Invoke ("doActionMenu", miAudio.clip.length);
		}
	}

	void doActionMenu(){
		if (index == 0) SceneManager.LoadScene("Juego");
		else if (index == 1) Application.Quit();
	}

	void moverCursor(){
		int h = (int) Input.GetAxis("Vertical");

		if (canMove && h == 1 && index >= 1) { 
			miAudio.clip = cambioMenu;
			miAudio.Play();
			start.transform.localScale = new Vector3(start.transform.localScale.x * 1.3f, start.transform.localScale.y * 1.3f, start.transform.localScale.z);
			exit.transform.localScale = new Vector3(start.transform.localScale.x / 1.3f, start.transform.localScale.y / 1.3f, start.transform.localScale.z);
			index--;
		}
		else if (canMove && h == -1 && index <= 0) {
			miAudio.clip = cambioMenu;
			miAudio.Play();
			start.transform.localScale = new Vector3(start.transform.localScale.x / 1.3f, start.transform.localScale.y / 1.3f, start.transform.localScale.z);
			exit.transform.localScale = new Vector3(start.transform.localScale.x * 1.3f, start.transform.localScale.y * 1.3f, start.transform.localScale.z);
			index++;
		}
	}

}
