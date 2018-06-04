using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed = 1.0f;
    public float jumpPower = 5.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int dir = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) dir -= 1;
        if (Input.GetKey(KeyCode.RightArrow)) dir += 1;

        transform.position += new Vector3(dir * speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpPower);
    }
}