using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PyramidController : MonoBehaviour
{
    public List<GameObject> pyramids;
    public int money;
    public Text moneyText;
    public Text getMoneyText;
    public AudioSource success;
    int pyramidsOpened;

    void Start()
    {
        getMoneyText.gameObject.SetActive(false);

        if(!PlayerPrefs.HasKey("pyramidsOpened"))
        {
            PlayerPrefs.SetInt("pyramidsOpened", pyramidsOpened);
        }
        pyramidsOpened = PlayerPrefs.GetInt("pyramidsOpened");

        foreach (Transform p in transform)
        {
            pyramids.Add(p.gameObject);
        }
        if(pyramidsOpened > 0)
        {
            for(int i = 0; i < pyramidsOpened; i++)
            {
                pyramids[0].gameObject.SetActive(false);
                pyramids.RemoveAt(0);
            }
        }

        if(!PlayerPrefs.HasKey("money"))
        {
            PlayerPrefs.SetInt("money", money);
        }
        money = PlayerPrefs.GetInt("money");
    }

    void Update()
    {
        moneyText.text = money.ToString();
    }

    public void RemovePyramid()
    {
        if (pyramids.Count > 1)
        {
            pyramidsOpened += 1;
            PlayerPrefs.SetInt("pyramidsOpened", pyramidsOpened);
            var a = pyramids[0].GetComponent<Animator>();
            a.SetBool("showAnimation", true);
            pyramids.RemoveAt(0);
            success.Play();
        }
        else
        {
            StartCoroutine(removeLastPyramid());
        }
    }
    
    IEnumerator removeLastPyramid()
    {
        var a = pyramids[0].GetComponent<Animator>();
        a.SetBool("showAnimation", true);
        pyramids.RemoveAt(0);
        success.Play();
        yield return new WaitForSeconds(2f);
        getMoneyText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        getMoneyText.gameObject.SetActive(false);
        money += 1000;
        PlayerPrefs.SetInt("money", money);
        foreach (Transform p in transform)
        {
            pyramids.Add(p.gameObject);
            p.gameObject.SetActive(true);
            var a2 = p.GetComponent<Animator>();
            a2.SetBool("showAnimation", false);
            pyramidsOpened = 0;
            PlayerPrefs.SetInt("pyramidsOpened", pyramidsOpened);
        }
    }
}
