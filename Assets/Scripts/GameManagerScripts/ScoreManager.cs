using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currentScoreValueText = default, bestScoreValueText = default;
    public static ScoreManager instance = null; //to call this script in playermovement.cs

    int currentScoreValue;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        currentScoreValue = 0;  //Set score to zero in start
        bestScoreValueText.text = PlayerPrefs.GetInt("Best").ToString();
    }



    public void IncreaseScore()
    {

        currentScoreValue += 1;
        //string currentScoreValueInString = currentScoreValue.ToString();  //cannot implicitly convert string to TextMeshProUGUI text hence a local string variable
        //currentScoreValueText.SetText(currentScoreValueInString);
        currentScoreValueText.text = currentScoreValue.ToString();  //better than introducing another local variable
        if (currentScoreValue > PlayerPrefs.GetInt("Best", 0))
        {
            bestScoreValueText.text = currentScoreValue.ToString();
            PlayerPrefs.SetInt("Best", currentScoreValue);
        }
        
        
    }


}
