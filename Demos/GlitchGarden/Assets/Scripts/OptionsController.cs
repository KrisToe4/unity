using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider m_volumeSlider;
    public Slider m_difficultySlider;

    private MusicManager m_musicManager;

    void Start()
    {
        m_musicManager = GameObject.FindObjectOfType<MusicManager>();

        m_volumeSlider.value = PlayerPrefManager.MasterVolume;
        m_difficultySlider.value = PlayerPrefManager.Difficulty;
    }

    void Update()
    {
        m_musicManager.UpdateVolume(m_volumeSlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPrefManager.MasterVolume = m_volumeSlider.value;
        PlayerPrefManager.Difficulty = m_difficultySlider.value;

        LevelManager.instance.LoadLevel("01a Start");
    }

    public void ResetToDefaults()
    {
        m_volumeSlider.value = 0.5f;
        m_difficultySlider.value = 2f;
    }    
}
