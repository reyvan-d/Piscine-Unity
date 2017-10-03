using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex01 : MonoBehaviour
{

    private Rigidbody2D rb;
    private float speed;
    private bool canJump;
    public bool alive;
    public Vector3 BeginPos;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (name == "red")
            speed = 10.0f;
        if (name == "yellow")
            speed = 15.0f;
        if (name == "blue")
            speed = 5.0f;
        BeginPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlatformWhiteSprite" || collision.gameObject.name == "red" || collision.gameObject.name == "yellow" || collision.gameObject.name == "blue")
        {
            canJump = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (name == "red" && collider.gameObject.name == "red_exit")
            GameObject.Find("Main Camera").GetComponent<CameraController_ex01>().exitRed = true;
        if (name == "yellow" && collider.gameObject.name == "yellow_exit")
            GameObject.Find("Main Camera").GetComponent<CameraController_ex01>().exitYellow = true;
        if (name == "blue" && collider.gameObject.name == "blue_exit")
            GameObject.Find("Main Camera").GetComponent<CameraController_ex01>().exitBlue = true;
        if (GameObject.Find("Main Camera").GetComponent<CameraController_ex01>().exitRed && GameObject.Find("Main Camera").GetComponent<CameraController_ex01>().exitYellow && GameObject.Find("Main Camera").GetComponent<CameraController_ex01>().exitBlue)
            Debug.Log("Level complete");
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (name == "red" && collider.gameObject.name == "red_exit")
            GameObject.Find("Main Camera").GetComponent<CameraController_ex01>().exitRed = false;
        if (name == "yellow" && collider.gameObject.name == "yellow_exit")
            GameObject.Find("Main Camera").GetComponent<CameraController_ex01>().exitYellow = false;
        if (name == "blue" && collider.gameObject.name == "blue_exit")
            GameObject.Find("Main Camera").GetComponent<CameraController_ex01>().exitBlue = false;
    }

    void FixedUpdate()
    {
        if (alive)
        {
            float translation = Input.GetAxis("Horizontal") * speed;
            translation *= Time.deltaTime;
            transform.Translate(translation, 0, 0);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (canJump)
                {
                    Vector2 force;
                    if (name == "red")
                        force = new Vector2(0.0f, 350.0f);
                    else if (name == "yellow")
                        force = new Vector2(0.0f, 450.0f);
                    else
                        force = new Vector2(0.0f, 200.0f);
                    rb.AddForce(force);
                    canJump = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && this.gameObject.name != "red")
        {
            alive = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && this.gameObject.name == "red")
        {
            alive = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && this.gameObject.name != "yellow")
        {
            alive = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && this.gameObject.name == "yellow")
        {
            alive = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && this.gameObject.name != "blue")
        {
            alive = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && this.gameObject.name == "blue")
        {
            alive = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = BeginPos;
            if (name != "red")
                alive = false;
            else
                alive = true;
        }
    }
}
