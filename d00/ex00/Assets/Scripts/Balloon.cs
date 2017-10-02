using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

	public float scale;
	private float delta;
	private float breath;

	// Use this for initialization
	void Start () {
		delta = 0.0f;
		breath = 8;
		scale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && breath > 0)
		{
			breath--;
			scale += 0.001f;
			transform.localScale += new Vector3 (scale, scale, scale);
			if (transform.localScale.x > 6)
			{
				transform.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
				Debug.Log ("Balloon life time: " + Mathf.RoundToInt(delta) + "s");
				GameObject.Destroy (this);
			}
		}
		if (transform.localScale.x > 0) {
			transform.localScale -= new Vector3 (0.08f, 0.08f, 0.08f);
		} else {
			Debug.Log ("Balloon life time: " + Mathf.RoundToInt (delta) + "s");
			GameObject.Destroy (this);
		}
		breath += 0.05f;
		delta += Time.deltaTime;
	}
}
