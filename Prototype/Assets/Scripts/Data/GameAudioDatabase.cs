using UnityEngine;

[CreateAssetMenu(fileName = "GameAudioDatabase", menuName = "MemoryGame/Audio Database")]
public class GameAudioDatabase : ScriptableObject
{
    public AudioClip flipSound;
    public AudioClip matchSound;
    public AudioClip mismatchSound;
    public AudioClip gameOverSound;
}
