using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex00 : MonoBehaviour {

	private Rigidbody2D rb;
	private float speed;
	private bool canJump;
	public bool alive;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		speed = 10.0f;
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.name == "PlatformWhiteSprite" || collision.gameObject.name == "red" || collision.gameObject.name == "yellow" || collision.gameObject.name == "blue")
		{
			canJump = true;
		}
	}

	void FixedUpdate ()
	{
		if (alive) {
			float translation = Input.GetAxis ("Horizontal") * speed;
			translation *= Time.deltaTime;
			transform.Translate (translation, 0, 0);
			transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, 0, 0);

			if (Input.GetKeyDown (KeyCode.Space)) {
				if (canJump) {
					Vector2 force = new Vector2 (0.0f, 300.0f);
					rb.AddForce (force);
					canJump = false;
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.Alpha1) && this.gameObject.name != "red") {
			alive = false;
		} else if (Input.GetKeyDown (KeyCode.Alpha1) && this.gameObject.name == "red") {
			alive = true;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2) && this.gameObject.name != "yellow") {
			alive = false;
		} else if (Input.GetKeyDown (KeyCode.Alpha2) && this.gameObject.name == "yellow") {
			alive = true;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3) && this.gameObject.name != "blue") {
			alive = false;
		} else if (Input.GetKeyDown (KeyCode.Alpha3) && this.gameObject.name == "blue") {
			alive = true;
		}
	}
}
