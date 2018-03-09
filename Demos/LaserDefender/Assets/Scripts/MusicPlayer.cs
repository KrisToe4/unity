using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    private static MusicPlayer instance;

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource m_musicPlayer;

    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            m_musicPlayer = GetComponent<AudioSource>();
            m_musicPlayer.clip = startClip;
            m_musicPlayer.Play();

            MusicPlayer.instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroying new duplicated Music Player
            Destroy(gameObject);
        }
    }

    void OnLevelWasLoaded(int level)
    {
        m_musicPlayer.Stop();

        switch (level)
        {
            case 0:
                m_musicPlayer.clip = startClip;
                break;
            case 1:
                m_musicPlayer.clip = gameClip;
                break;
            default:
                m_musicPlayer.clip = endClip;
                break;
        }

        m_musicPlayer.Play();
    }
}
