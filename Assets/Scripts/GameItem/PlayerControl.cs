using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 1.0f;
    private bool upsideDown;
    private bool onGround;
    public bool OnGround { set { onGround = value; } }
    private bool onPortal;
    public bool OnPortal { set { onPortal = value; } }

    // Use this for initialization
    void Start()
    {
        upsideDown = false;
        onPortal = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(onPortal);
        int dir = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) dir -= 1;
        if (Input.GetKey(KeyCode.RightArrow)) dir += 1;

        transform.position += new Vector3(dir * speed * Time.deltaTime, 0, 0);

        Debug.Log(onGround);
        if (!onGround) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!onPortal)
            {
                SetVelocity(0, 4);
                Teleport(0, -1);
                UpsideDown();
            }
        }
    }

    public void UpsideDown()
    {
        upsideDown = !upsideDown;
        transform.rotation *= Quaternion.Euler(0, 0, 180);
        GetComponent<Rigidbody2D>().gravityScale *= -1;
    }

    //upsideDownによって調整
    public void Teleport(float x, float y)
    {
        transform.position += upsideDown ? new Vector3(x, -y, 0) : new Vector3(x, y, 0);
    }

    //upsideDownによって調整
    public void SetVelocity(float x, float y)
    {
        GetComponent<Rigidbody2D>().velocity = upsideDown ? new Vector2(x, -y) : new Vector2(x, y);
    }


}