using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartColorsMiniGame : MonoBehaviour
{
    static bool isBought;
    public GameObject alert1;
    public GameObject alert2;
    PyramidController p;
    AudioSource buttons;

    void Start()
    {
        alert1.transform.position = new Vector3(0, 0, -50000);
        alert2.transform.position = new Vector3(0, 0, -50000);
        
        p = (PyramidController)FindObjectOfType(typeof(PyramidController));
        var obj = (ButtonSounds)FindObjectOfType(typeof(ButtonSounds));
        buttons = obj.buttons;
        
        if(!PlayerPrefs.HasKey("isBought"))
        {
            PlayerPrefs.SetInt("isBought", 0);
        }
        isBought = (PlayerPrefs.GetInt("isBought") == 1);
    }

    public void PlayOrBuy()
    {
        if(PlayerPrefs.GetInt("buttonSoundsOnlyInMenu") == 0)
        {
            buttons.Play();
        }

        if(isBought)
        {
            SceneManager.LoadScene("Colors");
        }
        else
        {
            alert1.transform.position = new Vector3(0, 0, -2);
        }
    }

    public void Buy()
    {
        if(PlayerPrefs.GetInt("buttonSoundsOnlyInMenu") == 0)
        {
            buttons.Play();
        }

        if(p.money < 10000)
        {
            alert1.transform.position = new Vector3(0, 0, -50000);
            alert2.transform.position = new Vector3(0, 0, -2);
        }
        else{
            isBought = true;
            PlayerPrefs.SetInt("isBought", 1);
            p.money -= 10000;
            PlayerPrefs.SetInt("money", p.money);
            alert1.transform.position = new Vector3(0, 0, -50000);
        }
    }

    public void Close1()
    {
        if(PlayerPrefs.GetInt("buttonSoundsOnlyInMenu") == 0)
        {
            buttons.Play();
        }
        alert1.transform.position = new Vector3(0, 0, -50000);
    }

    public void Close2()
    {
        if(PlayerPrefs.GetInt("buttonSoundsOnlyInMenu") == 0)
        {
            buttons.Play();
        }
        alert2.transform.position = new Vector3(0, 0, -50000);
    }
}
