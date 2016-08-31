using UnityEngine;
using System.Collections;

public enum MusicType
{
    None,
    Menu,
    Game
}

public class AudioManagerSingleton : MonoBehaviour
{
    private static AudioManagerSingleton instance = null;

    AudioSource audioSource;

    public AudioClip menuLoop;
    public AudioClip gameStart;
    public AudioClip gameLoop;

    float globalVolume = 0.2f;

    MusicType currentMusic = MusicType.None;

    void Awake()
    {
        EnforceSingleton();

        audioSource = GetComponent<AudioSource>();
    }

    void EnforceSingleton()
    {
        if (instance == null)   // Check if instance already exists
        {
            instance = this;    // if not, set instance to this
        }
        else if (instance != this)  // If instance already exists and it's not this
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);  //Sets this to not be destroyed when reloading scene

        ////Get a component reference to the attached BoardManager script
        //boardScript = GetComponent<BoardManager>();

        ////Call the InitGame function to initialize the first level 
        //InitGame();
    }

    public static AudioManagerSingleton GetInstance() { return instance; }

    public float GetGlobalVolume() { return globalVolume; }

	void OnLevelWasLoaded()
    {

	}

    void Start()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void SetMusic(MusicType inMusicType)
    {
        if (inMusicType == currentMusic) return;

        PlayMusic(inMusicType);
    }

    void PlayMusic(MusicType inMusicType)
    {
        StopAllCoroutines();

        switch (inMusicType)
        {
            case MusicType.None:
                {
                    Debug.LogWarning("fading music");
                    StartCoroutine(FadeMusic());
                    break;
                }
            case MusicType.Menu:
                {
                    currentMusic = MusicType.Menu;
                    audioSource.loop = true;
                    audioSource.clip = menuLoop;                    
                    audioSource.Play();                    
                    break;
                }
            case MusicType.Game:
                {
                    currentMusic = MusicType.Game;
                    audioSource.loop = false;
                    audioSource.clip = gameStart;
                    audioSource.Play();
                    StartCoroutine(PlayMusicDelayed(gameLoop, gameStart.length));
                    break;
                }
        }
    }

    IEnumerator FadeMusic()
    {        
        while(audioSource.volume > 0)
        {
            yield return new WaitForEndOfFrame();
            audioSource.volume -= 0.01f;
        }

        audioSource.Stop();
        audioSource.volume = globalVolume;
        currentMusic = MusicType.None;

        StopCoroutine(FadeMusic());
    }

    IEnumerator PlayMusicDelayed(AudioClip inClip, float inDelaySeconds)
    {
        yield return new WaitForSeconds(inDelaySeconds);

        Debug.LogWarning("play music delayed!");
        audioSource.clip = inClip;
        audioSource.Play();
        audioSource.loop = true;

        StopCoroutine(PlayMusicDelayed(inClip, inDelaySeconds));
    }
}