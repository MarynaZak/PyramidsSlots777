using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;
    public GameObject frame4;
    public GameObject frame5;    
    public List<GameObject> frames;
    int active = 0;

    void Start()
    {
        frames.AddRange(new List<GameObject>{frame1, frame2, frame3, frame4, frame5});
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(active < 4)
            {
                frames[active].SetActive(false);
                frames[active+1].SetActive(true);
                active += 1;
            }
            else{
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
