﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr : Singleton<GameMgr>
{
    public void GameClear()
    {
        SceneMgr.Instance.Next();
    }
}
