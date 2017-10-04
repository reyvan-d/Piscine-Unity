using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootmanController : MonoBehaviour {

    public Animator anim;
    public AudioClip confirmSound;
    private SpriteRenderer sprite;
    private AudioSource source;
    private Vector3 destination;
    private int xdirection, lastxDirection, ydirection, lastyDirection;
    private bool moving;
    public enum state
    {
        IdleUp = 0,
        IdleUpRight,
        IdleRight,
        IdleDownRight,
        IdleDown,
        MoveUp,
        MoveUpRight,
        MoveRight,
        MoveDownRight,
        MoveDown,
        AttackUp,
        AttackUpRight,
        AttackRight,
        AttackDownRight,
        AttackDown,
        DieUp,
        DieDown
    };

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        destination = transform.position;
        xdirection = 0;
        lastxDirection = 0;
        ydirection = 1;
        lastyDirection = 1;
        moving = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destination.z = -0.1f;
            source.PlayOneShot(confirmSound, 1.0f);
        }
        if (Math.Abs(transform.position.x - destination.x) > 0.5f)
        {
            if (transform.position.x > destination.x)
            {
                transform.Translate(-0.05f, 0.0f, 0.0f);
                xdirection = -1;
            }
            else
            {
                transform.Translate(0.05f, 0.0f, 0.0f);
                xdirection = 1;
            }
            lastxDirection = xdirection;
            if (!(Math.Abs(transform.position.y - destination.y) > 0.5f))
                lastyDirection = 0;
        }
        else
            xdirection = 0;
        if (Math.Abs(transform.position.y - destination.y) > 0.5f)
        {
            if (transform.position.y > destination.y)
            {
                transform.Translate(0.0f, -0.05f, 0.0f);
                ydirection = -1;
            }
            else
            {
                transform.Translate(0.0f, 0.05f, 0.0f);
                ydirection = 1;
            }
            lastyDirection = ydirection;
            if (!(Math.Abs(transform.position.x - destination.x) > 0.5f))
                lastxDirection = 0;
        }
        else
            ydirection = 0;
        if (Math.Abs(transform.position.x - destination.x) > 0.5f || Math.Abs(transform.position.y - destination.y) > 0.5f)
            moving = true;
        else
            moving = false;

        if (moving)
        {
            if (xdirection == 1 && ydirection == 1)
            {
                anim.SetInteger("State", (int)state.MoveUpRight);
                sprite.flipX = false;
            }
            else if (xdirection == 1 && ydirection == -1)
            {
                anim.SetInteger("State", (int)state.MoveDownRight);
                sprite.flipX = false;
            }
            else if (xdirection == -1 && ydirection == -1)
            {
                anim.SetInteger("State", (int)state.MoveDownRight);
                sprite.flipX = true;
            }
            else if (xdirection == -1 && ydirection == 1)
            {
                anim.SetInteger("State", (int)state.MoveUpRight);
                sprite.flipX = true;
            }
            else if (ydirection == 1)
            {
                anim.SetInteger("State", (int)state.MoveUp);
                sprite.flipX = false;
            }
            else if (xdirection == 1)
            {
                anim.SetInteger("State", (int)state.MoveRight);
                sprite.flipX = false;
            }
            else if (xdirection == -1)
            {
                anim.SetInteger("State", (int)state.MoveRight);
                sprite.flipX = true;
            }
            else if (ydirection == -1)
            {
                anim.SetInteger("State", (int)state.MoveDown);
                sprite.flipX = false;
            }
        }
        else
        {
            if (lastxDirection == 1 && lastyDirection == 1)
            {
                anim.SetInteger("State", (int)state.IdleUpRight);
                sprite.flipX = false;
            }
            else if (lastxDirection == 1 && lastyDirection == -1)
            {
                anim.SetInteger("State", (int)state.IdleDownRight);
                sprite.flipX = false;
            }
            else if (lastxDirection == -1 && lastyDirection == -1)
            {
                anim.SetInteger("State", (int)state.IdleDownRight);
                sprite.flipX = true;
            }
            else if (lastxDirection == -1 && lastyDirection == 1)
            {
                anim.SetInteger("State", (int)state.IdleUpRight);
                sprite.flipX = true;
            }
            else if (lastyDirection == 1)
            {
                anim.SetInteger("State", (int)state.IdleUp);
                sprite.flipX = false;
            }
            else if (lastxDirection == 1)
            {
                anim.SetInteger("State", (int)state.IdleRight);
                sprite.flipX = false;
            }
            else if (lastxDirection == -1)
            {
                anim.SetInteger("State", (int)state.IdleRight);
                sprite.flipX = true;
            }
            else if (lastyDirection == -1)
            {
                anim.SetInteger("State", (int)state.IdleDown);
                sprite.flipX = false;
            }
        }
    }
}
