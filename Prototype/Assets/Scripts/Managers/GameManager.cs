using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private List<Card> revealCards = new List<Card>();

    private void Awake()
    {
        Instance = this;
    }

    public void CardRevealed(Card _card)
    {
        revealCards.Add(_card);
        if(revealCards.Count==2)
        {
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        Card card1 = revealCards[0];
        Card card2 = revealCards[1];
        yield return new WaitForSeconds(0.5f);

        if (card1.cardId == card2.cardId)
        {
            card1.SetMatched();
            card2.SetMatched();
        }
        else
        {
            card1.FlipBack();
            card2.FlipBack();
        }

        revealCards.Clear();
           
    }
}
