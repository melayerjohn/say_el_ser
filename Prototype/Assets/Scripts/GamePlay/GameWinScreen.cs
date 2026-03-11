using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinScreen : MonoBehaviour
{
    public void OnReplayClick()
    {
        Debug.Log("GameWinScreen => OnReplayClick = " + PlayerPrefs.GetString("GAME_SAVE"));
        //GameManager.Instance.GetSaveSystem().Clear();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Debug.Log("GameWinScreen => OnReplayClick = " + PlayerPrefs.GetString("GAME_SAVE"));
    }
}
