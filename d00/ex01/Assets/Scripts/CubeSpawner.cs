using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

	public GameObject A, S, D;
    private float timeA, timeS, timeD;

	// Use this for initialization
	void Start () {
        timeA = 0.0f;
        timeS = 0.0f;
        timeD = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
		float spawnA = Random.Range (0.0f, 1.0f);
		if (spawnA < 0.01f && timeA > 1) {
            GameObject.Instantiate(A);
            timeA = 0.0f;
		}

		float spawnS = Random.Range (0.0f, 1.0f);
		if (spawnS < 0.01f && timeS > 1) {
			GameObject.Instantiate (S);
            timeS = 0.0f;
        }

		float spawnD = Random.Range (0.0f, 1.0f);
		if (spawnD < 0.01f && timeD > 1) {
			GameObject.Instantiate (D);
            timeD = 0.0f;
        }
        timeA += Time.deltaTime;
        timeS += Time.deltaTime;
        timeD += Time.deltaTime;
    }
}
