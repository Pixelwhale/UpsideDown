using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public void GameClear()
    {
        Debug.Log("game clear");
        StartCoroutine(GetComponent<SceneMgr>().Next());
    }
}
