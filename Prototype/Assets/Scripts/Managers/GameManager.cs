using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private List<Card> revealCards = new List<Card>();

    private Card firstCard;
    private Card secondCard;

    public int totalPairs;
    private int matchedPairs = 0;

    [SerializeField] private Transform popUpParent;
    [SerializeField] private GameObject gameWinScreen;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private SaveSystem saveSystem;
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private GridGenerator gridGenerator;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameSaveData data = saveSystem.Load();

        if (data != null)
        {
            scoreManager.score = data.score;
            scoreManager.UpdateScoreUI();
        }

        Debug.Log(" GameManager => Start => "+ scoreManager.score);
    }


    public void SetMode(int mode=2)
    {
        gridGenerator.Initialize(mode);
    }

    public void CardRevealed(Card _card)
    {
        if (firstCard == null)
        {
            firstCard = _card;
            return;
        }

        if (secondCard == null)
        {
            secondCard = _card;

            StartCoroutine(CheckMatch(firstCard, secondCard));

            firstCard = null;
            secondCard = null;
        }

    }

    IEnumerator CheckMatch(Card card1, Card card2)
    {
        yield return new WaitForSeconds(0.5f);


        if (card1.cardId == card2.cardId)
        {
            card1.SetMatched();
            card2.SetMatched();

            matchedPairs++;
            AudioManager.Instance.PlayMatch();
            scoreManager.AddMatchScore(matchedPairs);

            CheckGameComplete();
        }
        else
        {
            card1.FlipBack();
            card2.FlipBack();
        }

        revealCards.Clear();
           
    }

    public SaveSystem GetSaveSystem()
    {
        return saveSystem;
    }

    public ScoreManager GetScoreManager()
    {
        return scoreManager;
    }

    private void CheckGameComplete()
    {
        if(matchedPairs>=totalPairs)
        {
            Debug.Log("Game Completed ");
            
            OnGameCompleted();
        }
    }

    private void OnGameCompleted()
    {
        Debug.Log("Game Completed=> All pairs matched ");
        AudioManager.Instance.PlayGameOver();
        GameSaveData data = new GameSaveData();
        data.score = scoreManager.score;

        saveSystem.Save(data);
        Instantiate(gameWinScreen, popUpParent);
    }

    public void OnClickMenu()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
