using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int cardId;

    public GameObject front;
    public GameObject back;

    private bool isFlipped;

    private bool isMatched = false;
    public bool IsMatched => isMatched;

    public void OnCardClicked()
    {
        Debug.Log("Card=> OnCardClicked "+ cardId);
        if (isMatched || isFlipped)
            return;

        Flip();
        GameManager.Instance.CardRevealed(this);
    }

    public void Flip()
    {
        isFlipped = true;
        front.SetActive(true);
        back.SetActive(false);
        Debug.Log("Card=> Flip=> cardId = " + cardId );
    }

    public void FlipBack()
    {
        isFlipped = false;

        front.SetActive(false);
        back.SetActive(true);

        Debug.Log("Card=> FlipBack=> cardId = " + cardId);
    }

    public void SetMatched()
    {
        isMatched = true;
    }
}
