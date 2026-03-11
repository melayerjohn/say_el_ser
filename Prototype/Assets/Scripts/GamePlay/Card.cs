using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int cardId;

    public GameObject front;
    public GameObject back;

    public Image frontImage;
    public Sprite[] cardSprites;

    private bool isFlipped;

    private bool isMatched = false;
    public bool IsMatched => isMatched;

    [SerializeField] private float flipDuration = 0.2f;


    public void Initialize(int _id, Sprite _sprite)
    {
        cardId = _id;
        frontImage.sprite = _sprite;
        frontImage.preserveAspect = true;
    }

    public void OnCardClicked()
    {
        Debug.Log("Card=> OnCardClicked "+ cardId);
        if (isMatched || isFlipped)
            return;

        StartCoroutine(FlipAnimation());

        GameManager.Instance.CardRevealed(this);
    }

    IEnumerator FlipAnimation()
    {
        AudioManager.Instance.PlayFlip();
        yield return null;
        isFlipped = true;
        float time = 0;

        while (time<flipDuration)
        {
            transform.Rotate(0, 180 * Time.deltaTime / flipDuration, 0) ;
            time += Time.deltaTime;
            yield return null;
        }

        front.SetActive(true);
        back.SetActive(false);
        Debug.Log("Card=> Flip=> cardId = " + cardId );
    }

    public void FlipBack()
    {

        StartCoroutine(FlipBackAnimation());
        
    }

    IEnumerator FlipBackAnimation()
    {
        yield return null;

        float time = 0;

        while (time < flipDuration)
        {
            transform.Rotate(0, -180 * Time.deltaTime / flipDuration, 0);
            time += Time.deltaTime;
            yield return null;
        }

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
