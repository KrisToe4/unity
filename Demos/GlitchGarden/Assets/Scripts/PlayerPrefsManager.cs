using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefManager : MonoBehaviour {

    #region Key constants
    private const string MASTER_VOLUME = "master_volume";
    private const string DIFFICULTY = "difficulty";
    private const string LEVEL = "level_unlocked_";
    #endregion

    public static float MasterVolume
    {
        get
        {
            return PlayerPrefs.GetFloat(MASTER_VOLUME);
        }
        set
        {
            if ((value > 0f) && (value < 1f))
            {
                PlayerPrefs.SetFloat(MASTER_VOLUME, value);
                PlayerPrefs.Save();
            }
            else
            {
                Debug.LogError("Master Volume out of range");
            }
        }
    }

    #region
    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCount - 1)
        {
            PlayerPrefs.SetInt(LEVEL + level.ToString("00"), 1);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("Trying to unlock level not in build order");
        }
    }

    public static bool LevelUnlocked(int level)
    {
        bool levelUnlocked = false;

        if (level <= SceneManager.sceneCount - 1)
        {
            levelUnlocked = (PlayerPrefs.GetInt(LEVEL + level.ToString("00")) == 1);
        }
        else
        {
            Debug.LogError("Trying to query level not in build order");
        }

        return levelUnlocked;
    }
    #endregion

    public static float Difficulty
    {
        get
        {
            return PlayerPrefs.GetFloat(DIFFICULTY);
        }
        set
        {
            if ((value >= 1f) && (value <= 3f))
            {
                PlayerPrefs.SetFloat(DIFFICULTY, value);
                PlayerPrefs.Save();
            }
            else
            {
                Debug.LogError("Difficulty set to invalid value");
            }
        }
    }


}
