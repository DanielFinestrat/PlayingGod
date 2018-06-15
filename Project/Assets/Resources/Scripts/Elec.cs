using UnityEngine;
using System.Collections;

public class Elec : MonoBehaviour {

	private bool exito = false;
	private GameObject camara;

	public AudioClip sonidoFallo;
	private AudioSource miAudioS;


	void Start(){
		miAudioS = GetComponent<AudioSource>();
		camara = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Muerto") { exito = true; }
	}

	void comprobarExito(){
		if (!exito) {
			camara.GetComponent<Animator> ().Play ("Fallo");
			miAudioS.clip = sonidoFallo;
		}
		miAudioS.Play ();
	}

	void destruir2(){
		Destroy (this.gameObject);
	}

}
