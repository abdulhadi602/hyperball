using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI Scoretxt;
    private static int ScoreCounter;
    private static int highScore;
    private static string highScoreKey = "HighScore";
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        Scoretxt.SetText(""+ScoreCounter);
    }
    public void IncrementScore(int incrementBy)
    {
        ScoreCounter += incrementBy;
        Scoretxt.SetText(""+ScoreCounter);

    }
    public int GetScore()
    {
        if (ScoreCounter > highScore)
        {
            PlayerPrefs.SetInt(highScoreKey, ScoreCounter);
            PlayerPrefs.Save();
        }
        return ScoreCounter;
    }
    public void SetScore(int Score)
    {
        ScoreCounter = Score;
    }
}
