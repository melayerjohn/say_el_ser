using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int matches;
    public int turn = 0 ;

    public int matchPoints = 10;
    public int mismatchPenalty = -2;

    public TMP_Text scoreText;
    public TMP_Text matchesText;
    public TMP_Text turnText;


    public void AddMatchScore(int matchedPairs)
    {
        matches += matchedPairs;
        score += matchPoints;
        Debug.Log("Score: " + score);
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        scoreText.text = score.ToString();
        turnText.text = turn.ToString();
        matchesText.text = matches.ToString();
    }

}
