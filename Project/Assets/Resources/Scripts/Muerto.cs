﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Muerto : MonoBehaviour {

	public float timer = 1.5f;
	public float empuje = 150f;

	private Rigidbody2D myRigid;
	private GameObject player;
	private Jugador scriptJugador;
	public GameObject vivo;

	public bool isBoss = false;
	public bool hitted = false;

	private GameObject marcador;

	private SpriteRenderer sprite;
	private AudioSource miAudio;

	void Start(){
		sprite = this.GetComponent<SpriteRenderer> ();
		miAudio = GetComponent<AudioSource>();
		myRigid = gameObject.GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag ("Player");
		scriptJugador = player.GetComponent<Jugador> ();
		marcador = GameObject.FindGameObjectWithTag ("Marcador");
		mover();
	}

	void mover(){
		if(scriptJugador.isDead) myRigid.velocity = new Vector2(0, 0);
		if(!scriptJugador.isDead)myRigid.AddForce (Vector2.right * empuje);
		Invoke ("mover", timer);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "GameOver") gameOver();
		if (other.tag == "Electricidad" && isBoss && !hitted) {
			hitted = true;
			rojo();
		}
		else if (other.tag == "Electricidad") resucitar();
	}

	void rojo(){
		sprite.color = Color.red;
		Invoke ("volverNormal", 0.15f);
	}

	void volverNormal(){
		sprite.color = Color.white;
	}

	void gameOver(){
		myRigid.velocity = new Vector2(0, 0);
		player.transform.position = new Vector3 (transform.position.x + 1.5f, transform.position.y, transform.position.z);
		scriptJugador.isDead = true;
	} 

	void resucitar(){
		miAudio.Play ();

		if (isBoss) marcador.GetComponent<Puntuacion> ().miPuntuacion = marcador.GetComponent<Puntuacion> ().miPuntuacion + 2;
		else marcador.GetComponent<Puntuacion> ().miPuntuacion++;

		Instantiate (vivo, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z + 0.3f), transform.rotation);
		Destroy (gameObject);
	}

}
