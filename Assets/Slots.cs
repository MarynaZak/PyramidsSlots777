using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    public List<GameObject> slots;
    GameObject s1;
    GameObject s2;
    GameObject s3;
    Vector3 pos1;
    Vector3 pos2;
    Vector3 pos3;
    Animator a1;
    Animator a2;
    Animator a3;

    PyramidController p;

    AudioSource buttons;
    AudioSource music;

    void Start()
    {
        p = (PyramidController)FindObjectOfType(typeof(PyramidController));
        foreach (Transform s in transform)
        {
            slots.Add(s.gameObject);
        }

        slots.RemoveAt(0);
        s1 = slots[0];
        s2 = slots[1];
        s3 = slots[2];

        a1 = s1.GetComponent<Animator>();
        a2 = s2.GetComponent<Animator>();
        a3 = s3.GetComponent<Animator>();

        var obj = (ButtonSounds)FindObjectOfType(typeof(ButtonSounds));
        buttons = obj.buttons;

        var obj2 = (BackgroundMusic)FindObjectOfType(typeof(BackgroundMusic));
        music = obj2.music;

        if(PlayerPrefs.GetInt("musicOnlyInGame") == 1)
        {
            if(PlayerPrefs.GetInt("musicIsPlaying") == 0)
            {
                music.Play();
                PlayerPrefs.SetInt("musicIsPlaying", 1);
            }
        }
    }

    public void Spin()
    {
        if(PlayerPrefs.GetInt("buttonSoundsOnlyInMenu") == 0)
        {
            buttons.Play();
        }
        StartCoroutine(showOneByOne());
    }

    IEnumerator showOneByOne()
    {
        s1.gameObject.SetActive(false);
        s2.gameObject.SetActive(false);
        s3.gameObject.SetActive(false);
        
        a1.SetBool("showsPicture", false);
        a1.SetBool("showsPicture", false);
        a1.SetBool("showsPicture", false);
        
        List<float> yAxis = new List<float>{-0.28f, -0.056f, 0.167f};

        pos1 = s1.transform.localPosition;
        pos1.y = yAxis[Random.Range(0, yAxis.Count)];
        s1.transform.localPosition = pos1;

        pos2 = s2.transform.localPosition;
        pos2.y = yAxis[Random.Range(0, yAxis.Count)];
        s2.transform.localPosition = pos2;

        pos3 = s3.transform.localPosition;
        pos3.y = yAxis[Random.Range(0, yAxis.Count)];
        s3.transform.localPosition = pos3;

        if(pos1.y == pos2.y & pos1.y == pos3.y)
        {
            p.RemovePyramid();
        }

        s1.gameObject.SetActive(true);
        a1.SetBool("showsPicture", true);
        yield return new WaitForSeconds(0.5f);

        s2.gameObject.SetActive(true);
        a2.SetBool("showsPicture", true);
        yield return new WaitForSeconds(0.5f);

        s3.gameObject.SetActive(true);
        a3.SetBool("showsPicture", true);
        yield return new WaitForSeconds(0.5f);
    }
}
