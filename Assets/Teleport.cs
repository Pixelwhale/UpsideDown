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
		
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            other.GetComponent<PlayerControl>().Teleport(new Vector2(0,-3));
			other.GetComponent<PlayerControl>().UpsideDown();
        }
	}

//other.transform.position.y > this.transform.position.y && 
    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
