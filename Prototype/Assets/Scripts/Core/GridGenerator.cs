using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject cardPrefab;
    public RectTransform board;
    public CardSpriteDatabase spriteDatabase;

    public int rows = 2;
    public int coloumns = 2;
    public float spacing = 20f;
    public float margin = 50f;

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        float boardWidth = board.rect.width - (3* margin);
        float boardHeight = board.rect.height - (3 * margin);

        float cardWidth = (boardWidth - (coloumns - 1) * spacing) / coloumns;
        float cardHeight = (boardHeight - (rows - 1) * spacing) / rows;

        GameManager.Instance.totalPairs = (rows * coloumns) / 2;

        List<int> cardsIds = GenerateCardIDs(rows*coloumns);
        Shuffle(cardsIds);

        Debug.Log("GridGenerator=> GenerateGrid=> cardsIds = " + cardsIds.Count );
        for (int r=0; r<rows; r++ )
        {
            for (int c=0; c<coloumns; c++)
            {
                GameObject card = Instantiate(cardPrefab, board);
                RectTransform rt = card.GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(cardWidth,cardHeight);

                Card cardScript = card.GetComponent<Card>();
                int index = r * coloumns + c;
                cardScript.cardId = cardsIds[index];

                int id = cardsIds[index];
                Sprite sprite = spriteDatabase.cardSprites[id];
                cardScript.Initialize(id, sprite);
                //cardScript.cardId = r * coloumns + c;

                float startX = -(coloumns - 1) * (cardWidth + spacing) / 2f;
                float startY = (rows - 1) * (cardHeight + spacing) / 2f;

                //float startX = -boardWidth / 2f + cardWidth / 2f + margin;
                //float startY = boardHeight / 2f - cardHeight / 2f + margin;

                float x = startX + c * (cardWidth + spacing);
                float y = startY - r * (cardHeight + spacing);

                rt.anchoredPosition = new Vector2(x,y);
            }
        }

        
    }

    private List<int> GenerateCardIDs(int totalCards)
    {
        List<int> ids = new List<int>();

        int pairCount = totalCards / 2;

        for (int i = 0; i < pairCount; i++)
        {
            ids.Add(i);
            ids.Add(i);
        }

        return ids;
    }

    private void Shuffle(List<int> _list)
    {
        Debug.Log("GridGenerator=> Shuffle " );
        for (int i=0; i<_list.Count; i++)
        {
            int randomIndex = Random.Range(0,i+1);
            int temp = _list[i];
            _list[i] = _list[randomIndex];
            _list[randomIndex] = temp;
        }
    }

}
