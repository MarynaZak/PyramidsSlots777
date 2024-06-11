using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int health = 5;
    GameObject b;
    Vector3 pos;
    SpriteRenderer s;

    void Start()
    {
        b = transform.Find("Background").gameObject;
        pos = new Vector3(b.transform.localPosition.x, b.transform.localPosition.y);
        s = b.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckHealth();

    }

    void CheckHealth()
    {
        if(health == 4)
        {
            pos.x = -1.2f;
            pos.z = -1f;
            b.transform.localPosition = pos;
        }
        else if(health == 3)
        {
            pos.x = -2.4f;
            pos.z = -1f;
            b.transform.localPosition = pos;
            s.color = new Color(255, 255, 0);
        }
        else if(health == 2)
        {
            pos.x = -3.6f;
            pos.z = -1f;
            b.transform.localPosition = pos;
        }
        else if(health == 1)
        {
            pos.x = -4.8f;
            pos.z = -1f;
            b.transform.localPosition = pos;
            s.color = new Color(255, 0, 0);
        }
        else if(health == 0)
        {
            pos.x = -6f;
            pos.z = -1f;
            b.transform.localPosition = pos;
        }
    }
}
