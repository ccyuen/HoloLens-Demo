using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public TextMesh winText; // "you win!"
    public TextMesh scoreText; // displays score
    public TextMesh resetText; // click text to reset game
    private int score = 0;
    private bool reset = false;

    void Start()
    {
        winText.text = "";
        score = 0;
        reset = false;
    }

    // when a clown is hit
    void Blue()
    {
        score += 5;
    }

    void Red()
    {
        score += 3;
    }

    void Green()
    {
        score++;
    }

    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 21)
        {
            winText.text = "You win!";
            //Delay(5000).Wait();
            //winText1.CrossFadeAlpha(0.0f, 1.5f, false);
            //Thread.Sleep(3000);
            //scoreText.CrossFadeAlpha(0.0f, 1.5f, false);
            //winText2.CrossFadeAlpha(0.0f, 1.5f, false);
        }
        if (reset)
        {
            winText.text = "test this text";
        }
    }

    public virtual void OnInputClicked(InputEventData eventData)
    {
        // On each Select gesture, reset the game
        reset = true;
    }
}
