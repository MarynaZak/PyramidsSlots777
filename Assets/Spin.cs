using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    EnergyBar bar;
    Slots slots;
    AudioSource buttons;

    void Start()
    {
        bar = (EnergyBar)FindObjectOfType(typeof(EnergyBar));
        slots = (Slots)FindObjectOfType(typeof(Slots));
        var obj = (ButtonSounds)FindObjectOfType(typeof(ButtonSounds));
        buttons = obj.buttons;
    }

    public void ButtonPressed()
    {
        if(PlayerPrefs.GetInt("buttonSoundsOnlyInMenu") == 0)
        {
            buttons.Play();
        }
        if(bar.nowEnergy > 0)
        {
            bar.nowEnergy -= 1;
            PlayerPrefs.SetInt("energy", bar.nowEnergy);
            slots.Spin();
        }
    }
}
