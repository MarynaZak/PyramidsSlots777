using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource music;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
