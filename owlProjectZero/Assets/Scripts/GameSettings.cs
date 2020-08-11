﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public Text defeatedEnemies;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 144;
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy.numDefeatedEnemies >= Enemy.totalEnemies)
        {
            Win();
        }
    }

    private void Win()
    {
        defeatedEnemies.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        defeatedEnemies.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        defeatedEnemies.rectTransform.anchoredPosition = new Vector2(0f, 0f);
        defeatedEnemies.text = "YOU WIN!";
    }
}
