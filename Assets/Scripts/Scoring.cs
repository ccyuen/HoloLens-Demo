using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public Text scoreText;
    public Text winText1;
    public Text winText2;
    private bool firstHit = false;
    private int score = 0;

    void Start()
    {
        scoreText.text = "";
        winText1.text = "";
        winText2.text = "";
        score = 0;
    }

    // when a clown is hit
    void Blue()
    {
        score += 5;
        firstHit = true;
        SetScoreText();
    }

    void Red()
    {
        score += 3;
        firstHit = true;
        SetScoreText();
    }

    void Green()
    {
        score++;
        firstHit = true;
        SetScoreText();
    }

    void Update()
    {
        if (firstHit)
        {
            SetScoreText();
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 21)
        {
            winText1.text = "You win!";
            //Delay(5000).Wait();
            //winText1.CrossFadeAlpha(0.0f, 1.5f, false);
            winText2.text = "Say \"reset game\" to reset";
            //Thread.Sleep(3000);
            //scoreText.CrossFadeAlpha(0.0f, 1.5f, false);
            //winText2.CrossFadeAlpha(0.0f, 1.5f, false);
            firstHit = false;
        }
    }
}
