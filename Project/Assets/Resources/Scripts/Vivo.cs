using UnityEngine;
using System.Collections;

public class Vivo : MonoBehaviour {

	private float empuje = 3f;
	private GameObject puntoVentana;
	private bool irIzda = true;

	void Start(){
		puntoVentana = GameObject.FindGameObjectWithTag ("PuntoVentana");
	}

	void Update () {
		if (irIzda) moveToVentana ();
		else moveFromVentana ();
	}

	void moveToVentana(){
		transform.Translate (Vector2.left * Time.deltaTime * empuje);
		if (transform.position.x < -10) {
			transform.position = puntoVentana.transform.position;
			transform.localScale = new Vector3 (transform.localScale.x * -1 , transform.localScale.y, transform.localScale.z);
			irIzda = false;
		}
	}

	void moveFromVentana(){
		transform.Translate (Vector2.right* Time.deltaTime * empuje);
		if (transform.position.x > 13) Destroy (this.gameObject);
	}

}
