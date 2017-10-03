using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_ex01 : MonoBehaviour
{

    public bool exitRed, exitYellow, exitBlue;
    Vector3 pos;

    // Use this for initialization
    void Start()
    {
        exitRed = false;
        exitYellow = false;
        exitBlue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("red").GetComponent<playerScript_ex01>().alive)
        {
            GameObject temp = GameObject.Find("red");
            pos = new Vector3(temp.transform.position.x, temp.transform.position.y, -10);
            transform.position = pos;
        }

        if (GameObject.Find("yellow").GetComponent<playerScript_ex01>().alive)
        {
            GameObject temp = GameObject.Find("yellow");
            pos = new Vector3(temp.transform.position.x, temp.transform.position.y, -10);
            transform.position = pos;
        }

        if (GameObject.Find("blue").GetComponent<playerScript_ex01>().alive)
        {
            GameObject temp = GameObject.Find("blue");
            pos = new Vector3(temp.transform.position.x, temp.transform.position.y, -10);
            transform.position = pos;
        }
    }
}
