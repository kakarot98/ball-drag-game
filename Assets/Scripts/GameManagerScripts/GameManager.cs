using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    TextMeshProUGUI endScoreValueText, endBestScoreValueText;

    public static GameManager instance = null;
    public GameObject Player;


    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void Start()
    {
        if (instance == null) {
            instance = this;
        }
    }
        
    public void GameOver() {
        StartCoroutine(GameOverCoroutine());
    }

    

    IEnumerator GameOverCoroutine()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(1f);

        gameOverPanel.SetActive(true);
        endScoreValueText.text = ScoreManager.instance.currentScoreValue.ToString();
        endBestScoreValueText.text = PlayerPrefs.GetInt("Best").ToString();

        Player.SetActive(false);

        yield break;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
