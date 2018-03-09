using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float fadeTimer = 1f;

    private Image m_fadeInImage;
    private Color m_color = Color.black;

	// Use this for initialization
	void Start () {
        m_fadeInImage = GetComponent<Image>();
        m_fadeInImage.color = m_color;

        Debug.Log(PlayerPrefManager.MasterVolume.ToString());
        PlayerPrefManager.MasterVolume = 0.5f;
        Debug.Log(PlayerPrefManager.MasterVolume.ToString());
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad < fadeTimer)
        {
            float alphaChange = Time.deltaTime / fadeTimer;
            m_color.a -= alphaChange;
            m_fadeInImage.color = m_color;
        }
        else
        {
            gameObject.SetActive(false);
        }
	}
}
