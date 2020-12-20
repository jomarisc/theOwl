using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    private GameObject gameplayCanvas;
    public Text defeatedEnemies;
    public GameObject areaClearScreen;

    void OnEnable()
    {
        EnemyDead.OnEnemiesCleared += Win;
    }

    void OnDisable()
    {
        EnemyDead.OnEnemiesCleared -= Win;
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 144;
        gameplayCanvas = GameObject.Find("GameplayCanvas");
        areaClearScreen = gameplayCanvas.transform.Find("AreaClearNotification").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Enemy.numDefeatedEnemies >= Enemy.totalEnemies)
        // {
        //     Win();
        // }
    }

    private void Win()
    {
        /*defeatedEnemies.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        defeatedEnemies.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        defeatedEnemies.rectTransform.anchoredPosition = new Vector2(0f, 0f);
        defeatedEnemies.text = "YOU WIN!";*/
        areaClearScreen.SetActive(true);
    }
}
