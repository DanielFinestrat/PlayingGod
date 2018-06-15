using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {

	private TextMesh puntuacion;
	public int miPuntuacion = 000;

	void Start () {
		puntuacion = GetComponent<TextMesh>();
	
	}

	void Update () {
		if (miPuntuacion < 10) {
			puntuacion.text = "00" + miPuntuacion.ToString();
		}
		else if (miPuntuacion < 100) {
			puntuacion.text = "0" + miPuntuacion.ToString();
		}
		else puntuacion.text = miPuntuacion.ToString();
	}
}
