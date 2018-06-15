using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] muertos;
	private float[] temporizador = new float[] {3f, 5f, 7f, 10f};

	private GameObject player;
	private Jugador scriptJugador;

	private Puntuacion marcador;
	private int contador;
	private int miPuntuacion;
	private bool doIncrementar = false;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		scriptJugador = player.GetComponent<Jugador>();
		marcador = GameObject.FindGameObjectWithTag ("Marcador").GetComponent<Puntuacion>();
		Invoke ("crearMuerto", temporizador[Random.Range(0, temporizador.Length)]);
	}

	void Update(){
		if (contador < 6) {
			
			miPuntuacion = marcador.miPuntuacion - (contador * 10);

			if (miPuntuacion >= 10) {
				miPuntuacion = 0;
				contador++;
				doIncrementar = true;
			}

			if (miPuntuacion == 0 && doIncrementar) {
				doIncrementar = false;
				incrementarDificultad ();
			}
		}

	}

	void crearMuerto(){
		if(!scriptJugador.isDead) Instantiate (muertos [Random.Range(0, muertos.Length)], transform.position, transform.rotation);
		Invoke ("crearMuerto", temporizador[Random.Range(0, temporizador.Length)]);
	}

	void incrementarDificultad(){
		for (int i = 0; i <= temporizador.Length-1; i++) {
			temporizador[i] = (float)(temporizador [i] * 0.95f);
		}
	}

}
