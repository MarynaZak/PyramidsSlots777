using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenTutorial : MonoBehaviour
{
    AudioSource buttons;

    void Start()
    {
        var obj = (ButtonSounds)FindObjectOfType(typeof(ButtonSounds));
        buttons = obj.buttons;
    }
    
    public void Open()
    {
        buttons.Play();
        SceneManager.LoadScene("Tutorial");
    }
}
