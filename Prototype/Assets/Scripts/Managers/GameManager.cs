using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
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


        //revealCards.Add(_card);
        //if(revealCards.Count==2)
        //{
        //    Card card1 = revealCards[0];
        //    Card card2 = revealCards[1];

        //    revealCards.RemoveAt(0);
        //    revealCards.RemoveAt(0);

        //    StartCoroutine(CheckMatch(card1, card2));
        //}
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
            scoreManager.AddMatchScore();

            CheckGameComplete();
        }
        else
        {
            card1.FlipBack();
            card2.FlipBack();

            scoreManager.AddMismatchPenalty();
        }

        revealCards.Clear();
           
    }

    public SaveSystem GetSaveSystem()
    {
        return saveSystem;
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
}
