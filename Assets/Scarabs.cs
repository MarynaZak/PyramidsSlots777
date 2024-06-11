using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scarabs : MonoBehaviour
{
    Vector3 pos;
    float speed;
    HealthBar bar;
    Net net;
    int time = 60;
    public Text gameOverText;
    public Text winText;
    public Text countdown;
    public Button back;
    public AudioSource success;
    public AudioSource failure;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
        gameObject.SetActive(false);

        SetPositionOffsreen();

        gameObject.SetActive(true);
        speed = Random.Range(3f, 6f);

        bar = (HealthBar)FindObjectOfType(typeof(HealthBar));
        net = (Net)FindObjectOfType(typeof(Net));
        
        StartCoroutine(timer());
    }

    void FixedUpdate()
    {
        if (time > 0)
        {
            if(bar.health > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);

                Vector2 direction = Vector2.zero - (Vector2)transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angle-90);

                float dist = Vector2.Distance(Vector3.zero, transform.localPosition);
                float dist2 = Vector2.Distance(net.transform.localPosition, transform.localPosition);

                if(dist < 100f)
                {
                    bar.health -= 1;
                    RespawnScarab();
                }

                if(dist2 < 100f)
                {
                    RespawnScarab();
                }
            }
            else
            {
                time = 0;
            }
        }
        else
        {
            gameObject.SetActive(false);
            
            if(bar.health > 0)
            {
                PlayerPrefs.SetInt("energy", 100);
                countdown.gameObject.SetActive(false);
                winText.gameObject.SetActive(true);
                back.gameObject.SetActive(true);
                success.Play();
            }
            else{
                countdown.gameObject.SetActive(false);
                gameOverText.gameObject.SetActive(true);
                back.gameObject.SetActive(true);
                failure.Play();
            }
        }

    }

    void RespawnScarab()
    {
        SetPositionOffsreen();
        gameObject.SetActive(true);
        speed = Random.Range(3f, 6f);
    }

    void SetPositionOffsreen()
    {
        Vector3 right = new Vector3(Random.Range(Screen.width+30, Screen.width+60), Random.Range(0, Screen.height), -1);
        Vector3 left = new Vector3(Random.Range(-60, -30), Random.Range(0, Screen.height), -1);
        Vector3 up = new Vector3(Random.Range(0, Screen.width), Random.Range(Screen.height+30, Screen.height+60), -1);
        Vector3 down = new Vector3(Random.Range(0, Screen.width), Random.Range(-60, -30), -1);
        List<Vector3> whereToSpawn = new List<Vector3>{right, left, up, down};
        pos = whereToSpawn[Random.Range(0, whereToSpawn.Count)];
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }

    IEnumerator timer()
    {
        while(time > 0)
        {
            if(time > 0)
            {
                yield return new WaitForSeconds(1);
                time -= 1;
                countdown.text = "00:"+time.ToString();
            }
        }
        countdown.gameObject.SetActive(false);
    }
}
