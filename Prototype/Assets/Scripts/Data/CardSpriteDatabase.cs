using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardSpriteDatabase", menuName = "MemoryGame/Card Sprite Database")]
public class CardSpriteDatabase : ScriptableObject
{
    public List<Sprite> cardSprites;
}