using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    AudioSource buttons;

    void Start()
    {
        var obj = (ButtonSounds)FindObjectOfType(typeof(ButtonSounds));
        buttons = obj.buttons;
    }
    
    public void MainMenu()
    {
        if(PlayerPrefs.GetInt("buttonSoundsOnlyInMenu") == 0)
        {
            buttons.Play();
        }
        SceneManager.LoadScene("Menu");
    }
}
