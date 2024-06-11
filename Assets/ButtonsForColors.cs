using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsForColors : MonoBehaviour
{
    Colors pyramid;
    AudioSource buttons;

    void Start()
    {
        var obj = (ButtonSounds)FindObjectOfType(typeof(ButtonSounds));
        buttons = obj.buttons;
    }
    
    public void Press()
    {
        if(PlayerPrefs.GetInt("buttonSoundsOnlyInMenu") == 0)
        {
            buttons.Play();
        }
        pyramid = (Colors)FindObjectOfType(typeof(Colors));
        pyramid.buttonColor = transform.name;
    }
}
