using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour {

	private bool botonSuelto = true;
	public bool isDead = false;
	private bool estaPausado = false;
	private bool puedoMoverme = true;
	private bool puedeCrearMirilla = true;
	private bool itIsFirstTime = true;

	public GameObject mirillaInstanciar;

	public GameObject pauseText;
	private GameObject miPauseText;

	public GameObject[] carriles;
	public GameObject[] carrilesMirilla;
	private int contadorCarriles = 0;

	public AudioClip cambioCarril;
	public AudioClip gritoMuerte;
	public AudioClip sonidoGameOver;
	private AudioSource miAudio;

	private Animator myAnim;

	public GameObject gameOverText;
	public GameObject gameOverFilter;

	void Start(){
		miAudio = GetComponent<AudioSource>();
		transform.position = carriles [contadorCarriles].transform.position;
		myAnim = gameObject.GetComponent<Animator> ();
	}

	void Update (){

		if (Input.GetButtonDown("escape")) Application.Quit();

		myAnim.SetBool ("pulsandoPalanca", puedeCrearMirilla);

		if (isDead && itIsFirstTime) {
			itIsFirstTime = false;
			myAnim.SetBool ("isDead", isDead);
			deadSound ();
		}
		if(Input.GetButtonDown("Start") && !isDead) pausar();
		if(Input.GetButtonDown("Select")) irMenu();
		if (!estaPausado && !isDead) {
			if(puedoMoverme) moverCarril();
			if (Input.GetButtonDown ("Fire") && puedeCrearMirilla) {
				crearMirilla ();
				puedeCrearMirilla = false;
			}
			else if (Input.GetButtonUp ("Fire") && !puedeCrearMirilla) {
				puedoMoverme = true;
				puedeCrearMirilla = true;
			}
		}
	}

	void deadSound(){
		miAudio.clip = gritoMuerte;
		miAudio.Play();
		Invoke ("deadSound2", miAudio.clip.length);
	}

	void deadSound2(){
		miAudio.clip = sonidoGameOver;
		miAudio.Play();
	}

	//ManejarMirilla
	void crearMirilla(){
		puedoMoverme = false;
		Instantiate(mirillaInstanciar, carrilesMirilla[contadorCarriles].transform.position, carrilesMirilla[contadorCarriles].transform.rotation);
	}

	//Mover entre carriles
	void moverCarril(){
		int h = (int) Input.GetAxis("Vertical");

		if (botonSuelto && h == 1) { puedoMoverme = false; botonSuelto = false; Invoke("moveUp", 0.15f);  }
		else if (botonSuelto && h == -1) { puedoMoverme = false; botonSuelto = false; Invoke("moveDown", 0.15f); }

		if(h == 0) botonSuelto = true;
	}

	void moveUp(){
		if (contadorCarriles < carriles.Length-1 && !isDead && puedeCrearMirilla) {
			miAudio.clip = cambioCarril;
			miAudio.Play();
			contadorCarriles++;
			transform.position = carriles [contadorCarriles].transform.position;
		}
		Invoke ("resetPuedoMov", 0.1f);
	}

	void moveDown(){
		if (contadorCarriles > 0 && !isDead && puedeCrearMirilla) {
			miAudio.clip = cambioCarril;
			miAudio.Play();
			contadorCarriles--;
			transform.position = carriles [contadorCarriles].transform.position;
		}
		Invoke ("resetPuedoMov", 0.1f);
	}

	void resetPuedoMov(){
		puedoMoverme = true;
	}

	void irMenu(){
		SceneManager.LoadScene("Menu");
	}

	void pausar(){
		if (!estaPausado) {
			miPauseText = Instantiate(pauseText) as GameObject;
			Time.timeScale = 0;
			estaPausado = true;
		} else {
			Time.timeScale = 1;
			Destroy (miPauseText.gameObject);
			estaPausado = false;
		}
	}


	void instantiateGameOverText(){
		Instantiate (gameOverText);
		Instantiate (gameOverFilter);
	}

}
