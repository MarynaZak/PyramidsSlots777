using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    AudioSource buttons;

    void Start()
    {
        var obj = (ButtonSounds)FindObjectOfType(typeof(ButtonSounds));
        buttons = obj.buttons;
    }

    public void LoadGame()
    {
        buttons.Play();
        SceneManager.LoadScene("Slots");
    }
}
