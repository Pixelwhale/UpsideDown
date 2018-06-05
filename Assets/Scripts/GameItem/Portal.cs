using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject connectPortal;

    public bool upsideDown;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;

        //反転できない状態させる
        other.GetComponent<PlayerControl>().OnPortal = true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            other.transform.position = connectPortal.transform.position;
            if (this.upsideDown != connectPortal.GetComponent<Portal>().upsideDown){
                other.GetComponent<PlayerControl>().UpsideDown();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;

        //反転できる状態に戻る
        other.GetComponent<PlayerControl>().OnPortal = false;
    }
}
