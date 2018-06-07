using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private bool clear = false;

    void Start()
    {
    }

    /// <summary>
    /// Sent each frame where another object is within a trigger collider
    /// attached to this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerStay2D(Collider2D other)
    {
        if (clear) return;
        if (other.tag != "Player") return;
        if ((other.transform.position - this.transform.position).sqrMagnitude < 0.3f)
        {
            clear=true;
            GameMgr.Instance.GameClear();
        }
    }
}
