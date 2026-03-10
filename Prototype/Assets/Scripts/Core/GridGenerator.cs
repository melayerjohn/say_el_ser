using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject cardPrefab;
    public RectTransform board;

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
        float boardWidth = board.rect.width - (2* margin);
        float boardHeight = board.rect.height - (2 * margin);

        float cardWidth = (boardWidth - (coloumns - 1) * spacing) / coloumns;
        float cardHeight = (boardHeight - (rows - 1) * spacing) / rows;

        for (int r=0; r<rows; r++ )
        {
            for (int c=0; c<coloumns; c++)
            {
                GameObject card = Instantiate(cardPrefab, board);
                RectTransform rt = card.GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(cardWidth,cardHeight);

                //float startX = -(coloumns - 1) * (cardWidth + spacing) / 2f;
                //float startY = (rows - 1) * (cardHeight + spacing) / 2f;

                float startX = -boardWidth / 2f + cardWidth / 2f + margin;
                float startY = boardHeight / 2f - cardHeight / 2f - margin;

                float x = startX + c * (cardWidth + spacing);
                float y = startY - r * (cardHeight + spacing);

                rt.anchoredPosition = new Vector2(x,y);
            }
        }
    }
}
