using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteManager : MonoBehaviour
{
    private Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button btn;

    private bool isNotMuted = true;
    public AudioSource audioSource;

    void Start()
    {
        soundOnImage = btn.image.sprite;
    }

    public void ButtonClicked()
    {
        if (isNotMuted)
        {
            isNotMuted = PlayerPrefs.GetInt("MUTED") == 1;
            btn.image.sprite = soundOffImage;
            isNotMuted = false;
            audioSource.mute = true;
            PlayerPrefs.SetInt("MUTED", isNotMuted ? 1 : 0); //We are setting player preferences value to an integer value based on whether the boolean isMuted is true 
        }
        else
        {
            //isNotMuted = PlayerPrefs.GetInt("MUTED") == 1;
            btn.image.sprite = soundOnImage;
            isNotMuted = true;
            audioSource.mute = false;
            //PlayerPrefs.SetInt("MUTED", isNotMuted ? 1 : 0); //We are setting player preferences value to an integer value based on whether the boolean isMuted is true
        }
    }
}
