using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	public float speed;
	public char letter;
	// Use this for initialization
	void Start () {
		speed = Random.Range(0.1f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
		if (letter == 'A') {
			if (Input.GetKeyDown (KeyCode.A)) {
				GameObject.Destroy (this.gameObject);
                Debug.Log("Precision: " + (-(-4 - transform.position.y)) * 10);
			}
		}

		if (letter == 'S') {
			if (Input.GetKeyDown (KeyCode.S)) {
				GameObject.Destroy (this.gameObject);
                Debug.Log("Precision: " + (-(-4 - transform.position.y)) * 10);
            }
		}

		if (letter == 'D') {
			if (Input.GetKeyDown (KeyCode.D)) {
				GameObject.Destroy (this.gameObject);
                Debug.Log("Precision: " + (-(-4 - transform.position.y)) * 10);
            }
		}
        transform.Translate(0.0f, -speed, 0.0f);
		if (transform.localPosition.y < -4.0f) {
			GameObject.Destroy (this.gameObject);
		}
	}
}
