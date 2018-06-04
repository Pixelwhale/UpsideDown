using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    /// <summary>
    /// Sent each frame where another object is within a trigger collider
    /// attached to this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
        if (Input.GetKeyDown(other.GetComponent<PlayerControl>().DownKey()))
        {
            other.GetComponent<PlayerControl>().SetVelocity(0, 4);
            other.GetComponent<PlayerControl>().Teleport(0, -1);
            other.GetComponent<PlayerControl>().UpsideDown();
        }
    }
}
