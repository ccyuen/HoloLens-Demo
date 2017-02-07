using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;
using HoloToolkit.Unity.InputModule;

public class SpeechHandler : MonoBehaviour
{
    // for class TapToPlace check to make sure that user is not picking up multiple objects
    public static bool HoldingObject;

    public GameObject world;
    public CannonBehavior Cannon;
    //public AudioSource backgroundMusic;

    public string HidePlaneCmd;//= "hide world";
    public string ShowPlaneCMD;//= "show world";
    public string ResetSceneCmd;// = "reset scene";

    public string ShootCmd;//= "fire";
    public string EnableShootCmd;//= "enable";
    public string DisableShootCmd;// = "disable";
    public static bool shooting;

    private KeywordRecognizer _keywordRecognizer;

    void Start()
    {
        _keywordRecognizer = new KeywordRecognizer(new[] { HidePlaneCmd, ShowPlaneCMD, ResetSceneCmd, ShootCmd, EnableShootCmd, DisableShootCmd });
        _keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        _keywordRecognizer.Start();
        shooting = false;
        HoldingObject = false;
    }

    /*public virtual void OnInputClicked(InputEventData eventData)
    {
        // On each Select gesture, toggle whether the user is in placing mode.
        if (!shooting)
            selected = !selected;
    }*/

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        var cmd = args.text;
        if (cmd == HidePlaneCmd)
        {
            world.SetActive(false);
        }
        else if (cmd == ShowPlaneCMD)
        {
            world.SetActive(true);
        }
        else if (cmd == ShootCmd)
        {
            Cannon.Shoot();
        }
        else if (cmd == ResetSceneCmd)
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }
        else if (cmd == EnableShootCmd)
        {
            if (!HoldingObject)
            {
                Cannon.enableShoot();
                shooting = true;
            }
        }
        else if (cmd == DisableShootCmd)
        {
            if (!HoldingObject)
            {
                Cannon.disableShoot();
                shooting = false;
            }
        }
    }

    private void OnDestroy()
    {
        if (_keywordRecognizer != null)
        {
            if (_keywordRecognizer.IsRunning)
            {
                _keywordRecognizer.Stop();
            }
            _keywordRecognizer.Dispose();
        }
    }
}
