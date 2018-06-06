using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
	public bool right;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Edge") return;
        if (right) GetComponentInParent<PlayerControl>().RightCollide = true;
		else GetComponentInParent<PlayerControl>().LeftCollide = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Edge") return;
        if (right) GetComponentInParent<PlayerControl>().RightCollide = false;
		else GetComponentInParent<PlayerControl>().LeftCollide = false;
    }
}
