using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currentScoreText = default;

    
    int currentScoreValue;

    public static ScoreManager instance = null;

    void Start()
    {
        if (instance == null) {
            instance = this;
        }
        currentScoreValue = 0;
    }



    public void IncreaseScore() {

        currentScoreValue += 1;
        string currentScoreValueText = currentScoreValue.ToString();
        currentScoreText.SetText(currentScoreValueText);
        
        
    }


}
