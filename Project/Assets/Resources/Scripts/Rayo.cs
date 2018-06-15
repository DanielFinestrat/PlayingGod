using UnityEngine;
using System.Collections;

public class Rayo : MonoBehaviour {

	private float minimum = 0.2f;
	private float maximum = 1f;
	private float duration = 0.15f;
	private float startTime;
	private SpriteRenderer sprite;

	private bool fadeIn = true;
	private bool fadeOut = false;

	void Start() {
		sprite = this.GetComponent<SpriteRenderer> ();
		startTime = Time.time;
	}

	void Update() {

		float t = (Time.time - startTime) / duration;

		if(fadeIn) sprite.color = new Color(1f,1f,1f,Mathf.SmoothStep(minimum, maximum, t));
		if(fadeOut) sprite.color = new Color(1f,1f,1f,Mathf.SmoothStep(maximum, 0, t));

		if (sprite.color.a == 1){
			fadeIn = false;
			fadeOut = true;
		}

		if (sprite.color.a <= 0.1) Destroy (this.gameObject);
	}
}
