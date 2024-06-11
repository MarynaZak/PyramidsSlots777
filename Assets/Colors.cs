using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colors : MonoBehaviour
{
    public List<GameObject> colors;
    SpriteRenderer s;
    Animator a1;
    Animator a2;
    GameObject nextColor;
    GameObject pastColor;
    static float animationTime = 0.5f;
    static float showColorTime = 1.5f;
    float waitTime = animationTime + showColorTime;
    public string buttonColor;
    string pastButton;
    public Text gameOverText;
    bool play = true;
    public Text scoreText;
    public Text bestScoreText;
    int score;
    int bestScore;
    int time;
    public Button back;
    public AudioSource failure;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        bestScoreText.gameObject.SetActive(false);
        back.gameObject.SetActive(false);

        if(!PlayerPrefs.HasKey("bestScore"))
        {
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
        bestScore = PlayerPrefs.GetInt("bestScore");

        pastButton = buttonColor;

        foreach (Transform c in transform)
        {
            colors.Add(c.gameObject);
        }
        colors.RemoveAt(colors.Count - 1);

        nextColor = colors[Random.Range(0, colors.Count)];
        colors.Remove(nextColor);
        a1 = nextColor.GetComponent<Animator>();
        a1.SetBool("isVisible", true);

        StartCoroutine(wait());
        StartCoroutine(increaseSpeed());
    }

    void Update()
    {
        if(buttonColor != pastButton)
        {
            onButtonSelected();
        }
    }

    IEnumerator wait()
    {
        while (play)
        {
            var pastButton2 = buttonColor;
            yield return new WaitForSeconds(waitTime);

            if(buttonColor == pastButton2)
            {
                whenNoButtonPressed();
            }

            if(!play){
                yield break;
            }

            pastColor = nextColor;
            a2 = a1;
            nextColor = colors[Random.Range(0, colors.Count)];
            colors.Remove(nextColor);
            a1 = nextColor.GetComponent<Animator>();
            a2.SetBool("isVisible", false);
            a1.SetBool("isVisible", true);
            colors.Add(pastColor);
        }
    }

    void onButtonSelected()
    {
        if(buttonColor.ToLower() != nextColor.name)
        {
            EndGame();
        }
        else
        {
            score += 1;
        }

        pastButton = buttonColor;
    }

    void whenNoButtonPressed()
    {
        EndGame();
    }

    void EndGame()
    {
        a1.SetBool("isVisible", false);
        
        play = false;

        if(bestScore < score)
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }

        scoreText.text += score.ToString();
        bestScoreText.text = "Best score: " + bestScore.ToString();

        gameOverText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        bestScoreText.gameObject.SetActive(true);
        back.gameObject.SetActive(true);
        failure.Play();
    }

    IEnumerator increaseSpeed()
    {
        while(play)
        {   if(showColorTime > 0.5f)
            {
                yield return new WaitForSeconds(1);
                time += 1;
                if(time % 5 == 0)
                {
                    showColorTime -= 0.2f;
                    waitTime = animationTime + showColorTime;
                }
            }
            else{
                yield break;
            }
        }
    }
}
