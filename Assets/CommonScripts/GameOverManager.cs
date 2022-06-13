using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    private static GameOverManager _instance;
    public GameObject gameOverCanvas;
    public TMPro.TMP_Text OverText;

    private void Awake()
    {

    }

    public static GameOverManager Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<GameOverManager>();
            if (_instance == null)
            {
                var go = new GameObject(nameof(GameOverManager));
                _instance = go.AddComponent<GameOverManager>();
            }
            return _instance;
        }
    }

    public void setGameOver()
    {
        OverText.SetText("GameOver!!");
        gameOverCanvas.SetActive(true);
    }

    public void setGameClear()
    {
        OverText.SetText("GameClear!!");
        gameOverCanvas.SetActive(true);
    }
}