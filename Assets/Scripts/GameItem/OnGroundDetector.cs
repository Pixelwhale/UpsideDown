using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Edge") return;
        GetComponentInParent<PlayerControl>().OnGround = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Edge") return;
        GetComponentInParent<PlayerControl>().OnGround = false;
    }
}
