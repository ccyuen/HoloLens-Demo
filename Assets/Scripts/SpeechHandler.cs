using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class SpeechHandler : MonoBehaviour
{
    public GameObject world;
    public CannonBehavior Cannon;
    bool selected = false;
    //public AudioSource backgroundMusic;

    public string HidePlaneCmd = "hide world";
    public string ShowPlaneCMD = "show world";
    public string ResetSceneCmd = "reset scene";
    public string ShootCmd = "fire";
    public string EnableShootCmd = "enable";
    public string DisableShootCmd = "disable";
    public string EnableMusicCmd = "on";
    public string DisableMusicCmd = "off";
    public string SpawnCmd = "spawn";
    public string DestroyCmd = "destroy";

    private bool isGazing = false;

    private KeywordRecognizer _keywordRecognizer;

    void Start()
    {
        _keywordRecognizer = new KeywordRecognizer(new[] { HidePlaneCmd, ShowPlaneCMD, ResetSceneCmd, ShootCmd, EnableShootCmd, DisableShootCmd, EnableMusicCmd, DisableMusicCmd });
        _keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        _keywordRecognizer.Start();
        //backgroundMusic = GetComponent<AudioSource>();
    }

    void OnSelect()
    {
        // On each Select gesture, toggle whether the user is in placing mode.
        selected = !selected;
    }

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
            Cannon.enableShoot();
        }
        else if (cmd == DisableShootCmd)
        {
            Cannon.disableShoot();
        }/*
        else if (cmd == EnableMusicCmd)
        {
           playBackgroundMusic(1);
        }
        else if (cmd == DisableMusicCmd)
        {
            playBackgroundMusic(0);
        }*/
        else if (cmd == SpawnCmd)
        {
            if (selected)
                spawn();   
        }
        else if (cmd == DestroyCmd)
        {
            if (selected)
                destroy();
        }
    }

    /*
    private void playBackgroundMusic(int num)
    {
        if (num == 1) // play music
        {
            backgroundMusic.mute = false;
        }
        else if (num == 0) // stop music
        {
            backgroundMusic.mute = true;
        }
    }*/

    
    // create more holograms that is being gazed at
    void spawn()
    {
        //if (FocusedObject != null)
            //GameObject newObject = (GameObject)Instantiate(Resources.Load("bulbasaur"));
    }

    // destroy hologram that is being gazed at
    void destroy()
    {
        //destroy(gameObject);
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
