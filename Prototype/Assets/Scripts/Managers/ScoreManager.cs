using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score;

    public int matchPoints = 10;
    public int mismatchPenalty = -2;

    public TMP_Text scoreText;

    [SerializeField]private bool isAddMismatchPenalty;

    private void Awake()
    {
        Instance = this;
    }

    public void AddMatchScore()
    {
        score += matchPoints;
        Debug.Log("Score: " + score);
        UpdateScoreUI();
    }

    public void AddMismatchPenalty()
    {
        if (isAddMismatchPenalty)
        {
            score += mismatchPenalty;
            Debug.Log("Score: " + score);
            UpdateScoreUI();
        }
    }

    private void UpdateScoreUI()
    {
        scoreText.text = score.ToString();
    }
}
