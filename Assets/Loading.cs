using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(loading());
    }

    IEnumerator loading()
    {
        anim.Play("Loading");
        float length = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(length);
        SceneManager.LoadScene("Menu");
    }
}
