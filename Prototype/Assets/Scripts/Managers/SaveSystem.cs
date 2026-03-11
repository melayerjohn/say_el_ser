using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{

    private const string SAVE_KEY = "GAME_SAVE";

    public void Save(GameSaveData _data)
    {
        string dataString = JsonUtility.ToJson(_data);
        PlayerPrefs.SetString(SAVE_KEY, dataString);
        PlayerPrefs.Save();
    }

    public GameSaveData Load()
    {
        if (!PlayerPrefs.HasKey(SAVE_KEY))
            return null;

        string json = PlayerPrefs.GetString(SAVE_KEY);
        return JsonUtility.FromJson<GameSaveData>(json);
    }

    public void Clear()
    {
        PlayerPrefs.DeleteKey(SAVE_KEY);
    }
}
