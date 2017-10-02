using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

	public GameObject A, S, D;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float spawnA = Random.Range (0.0f, 1.0f);
		if (spawnA < 0.01f) {
			GameObject.Instantiate (A);
		}
		float spawnS = Random.Range (0.0f, 1.0f);
		if (spawnS < 0.01f) {
			GameObject.Instantiate (S);
		}
		float spawnD = Random.Range (0.0f, 1.0f);
		if (spawnD < 0.01f) {
			GameObject.Instantiate (D);
		}
	}
}
