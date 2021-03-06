﻿using UnityEngine;
using System.Collections;

public class Mirilla : MonoBehaviour {

	private bool goLeft = true;
	private float empuje = 7f;
	public GameObject elec;
	public GameObject rayo;

	private GameObject player;
	private Jugador scriptJugador;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		scriptJugador = player.GetComponent<Jugador> ();
	}

	void Update(){
		if(scriptJugador.isDead) Destroy(gameObject);
		if (Input.GetButtonUp ("Fire")) soltarElec();
		if(goLeft) transform.Translate (Vector2.left * Time.deltaTime * empuje);
		else transform.Translate (Vector2.right * Time.deltaTime * empuje);
	} 



	void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider.gameObject.tag == "Muerto") {
			Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
		}
	}
	void OnCollisionStay2D(Collision2D collision){
		if (collision.collider.gameObject.tag == "Muerto") {
			Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
		}
	}
	void OnCollisionExit2D(Collision2D collision){
		if (collision.collider.gameObject.tag == "Muerto") {
			Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
		}
	}



	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Pared") {
			goLeft = !goLeft;
			empuje = 3f;
		}
	}

	void soltarElec(){
		Instantiate (rayo, transform.position, transform.rotation);
		Instantiate (elec, transform.position, transform.rotation);
		Destroy (this.gameObject);
	}

}
