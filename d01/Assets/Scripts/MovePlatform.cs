using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{

    private float xPos;
    private bool right;
    // Use this for initialization
    void Start()
    {
        xPos = 8;
        right = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (right)
            xPos += 0.1f;
        else
            xPos -= 0.1f;
        if (xPos > 16.0f)
            right = false;
        if (xPos < 8.0f)
            right = true;
        Vector3 pos = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = pos;
    }
}
