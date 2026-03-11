using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private  AudioSource audioSource;

    public GameAudioDatabase audioDatabase;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFlip()
    {
        audioSource.PlayOneShot(audioDatabase.flipSound);
    }

    public void PlayMatch()
    {
        audioSource.PlayOneShot(audioDatabase.matchSound);
    }

    public void PlayMismatch()
    {
        audioSource.PlayOneShot(audioDatabase.mismatchSound);
    }

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(audioDatabase.gameOverSound);
    }
}
