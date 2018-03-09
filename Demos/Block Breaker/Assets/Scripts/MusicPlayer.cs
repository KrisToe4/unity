using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    private static MusicPlayer m_Singleton;

    private AudioSource m_audio;

    void Awake()
    {
        if (m_Singleton != null)
        {
            // Destroying new duplicated Music Player
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        if (m_Singleton == null)
        {
            m_audio = GetComponent<AudioSource>();
            m_audio.Play();

            m_Singleton = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
