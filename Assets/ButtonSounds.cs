using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource buttons;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
