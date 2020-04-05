using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    TextMeshProUGUI endScoreValueText, endBestScoreValueText;

    public static GameManager instance = null;

    private void Start()
    {
        if (instance == null) {
            instance = this;
        }
    }

    public void GameOver() {
        gameOverPanel.SetActive(true);
        endScoreValueText.text = ScoreManager.instance.currentScoreValue.ToString();
        endBestScoreValueText.text = PlayerPrefs.GetInt("Best").ToString();
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
