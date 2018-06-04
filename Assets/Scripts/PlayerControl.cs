﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpPower = 5.0f;

    private bool upsideDown;

    // Use this for initialization
    void Start()
    {
        upsideDown = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        int dir = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) dir -= 1;
        if (Input.GetKey(KeyCode.RightArrow)) dir += 1;

        transform.position += new Vector3(dir * speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space)) Velocity(0, jumpPower);
    }

    public void UpsideDown()
    {
        upsideDown = !upsideDown;
        transform.rotation *= Quaternion.Euler(0, 0, 180);
        GetComponent<Rigidbody2D>().gravityScale *= -1;
        jumpPower *= -1;
    }

    public void Teleport(float x, float y)
    {
        transform.position += (upsideDown) ? new Vector3(x, -y, 0) : new Vector3(x, y, 0);
    }

    public void Velocity(float x, float y)
    {
        GetComponent<Rigidbody2D>().velocity = (upsideDown) ? new Vector2(x, -y) : new Vector2(x, y);
    }
}