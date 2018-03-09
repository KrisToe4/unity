using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] levelMusicChangeArray;

    private AudioSource m_audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Persistent object - Don't destroy: " + name);
    }

    // Use this for initialization
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    public void UpdateVolume(float volume)
    {
        m_audioSource.volume = volume;
    }

    private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        AudioClip levelMusic = levelMusicChangeArray[scene.buildIndex];
        if (levelMusic != null)
        {
            m_audioSource.clip = levelMusic;
            m_audioSource.loop = true;
            m_audioSource.Play();
        }
    }


}
