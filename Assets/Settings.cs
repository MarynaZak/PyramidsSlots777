using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject alert;
    AudioSource buttons;
    public Toggle toggle1;
    public Toggle toggle2;
    static bool musicOnlyInGame;
    static bool buttonSoundsOnlyInMenu;
    AudioSource music;

    void Start()
    {
        var obj = (ButtonSounds)FindObjectOfType(typeof(ButtonSounds));
        buttons = obj.buttons;

        var obj2 = (BackgroundMusic)FindObjectOfType(typeof(BackgroundMusic));
        music = obj2.music;

        if(!PlayerPrefs.HasKey("musicOnlyInGame"))
        {
            PlayerPrefs.SetInt("musicOnlyInGame", 1);
        }
        musicOnlyInGame = (PlayerPrefs.GetInt("musicOnlyInGame") == 1);

        if(!PlayerPrefs.HasKey("buttonSoundsOnlyInMenu"))
        {
            PlayerPrefs.SetInt("buttonSoundsOnlyInMenu", 1);
        }
        buttonSoundsOnlyInMenu = (PlayerPrefs.GetInt("buttonSoundsOnlyInMenu") == 1);

        toggle1.isOn = musicOnlyInGame;
        toggle2.isOn = buttonSoundsOnlyInMenu;

        if(!PlayerPrefs.HasKey("musicIsPlaying"))
        {
            PlayerPrefs.SetInt("musicIsPlaying", 0);
        }

        if(PlayerPrefs.GetInt("musicOnlyInGame") == 1)
        {
            music.Stop();
            PlayerPrefs.SetInt("musicIsPlaying", 0);
        }
    }

    public void ShowSettings()
    {
        buttons.Play();
        alert.gameObject.SetActive(true);
    }

    public void MusicOnlyInGame()
    {
        buttons.Play();
        musicOnlyInGame = toggle1.isOn;
        PlayerPrefs.SetInt("musicOnlyInGame", musicOnlyInGame ? 1 : 0);
        
        if(PlayerPrefs.GetInt("musicOnlyInGame") == 0)
        {
            music.Play();
            PlayerPrefs.SetInt("musicIsPlaying", 1);
        }
        else{
            music.Stop();
            PlayerPrefs.SetInt("musicIsPlaying", 0);
        }
    }

    public void ButtonSoundsOnlyInMenu()
    {
        buttons.Play();
        buttonSoundsOnlyInMenu = toggle2.isOn;
        PlayerPrefs.SetInt("buttonSoundsOnlyInMenu", buttonSoundsOnlyInMenu ? 1 : 0);
    }

    public void CloseSettings()
    {
        buttons.Play();
        alert.gameObject.SetActive(false);
    }
}
