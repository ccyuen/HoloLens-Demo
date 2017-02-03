using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class SpeechHandler : MonoBehaviour
{
    public string HidePlaneCmd = "hide plane";
    public GameObject Plane;

    public string ShootCmd = "shoot";
    public CannonBehavior Cannon;

    public string ResetSceneCmd = "reset scene";
    public string ChangeShootCmd = "enable";
    public string SpawnCmd = "spawn";
    public string DestroyCmd = "destroy";
    private bool isGazing = false;

    private KeywordRecognizer _keywordRecognizer;

    void Start()
    {
        _keywordRecognizer = new KeywordRecognizer(new[] { HidePlaneCmd, ResetSceneCmd, ShootCmd, ChangeShootCmd });
        _keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        _keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        var cmd = args.text;
        if (cmd == HidePlaneCmd)
        {
            Plane.SetActive(false);
        }
        else if (cmd == ShootCmd)
        {
            Cannon.Shoot();
        }
        else if (cmd == ResetSceneCmd)
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }
        else if (cmd == ChangeShootCmd)
        {
            Cannon.enableShoot();
        }/*
        else if (cmd == SpawnCmd)
        {
            spawn();   
        }
        else if (cmd == DestroyCmd)
        {
            destroy();
        }*/
    }

    /*
    // create more holograms that is being gazed at
    void spawn()
    {
        if (FocusedObject != null)
            GameObject newObject = (GameObject)Instantiate(Resources.Load("bulbasaur"));
    }

    // destroy hologram that is being gazed at
    void destroy()
    {

    }*/
   

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
