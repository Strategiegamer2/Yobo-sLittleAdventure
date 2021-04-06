using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Audio_play : MonoBehaviour
{
    public AudioClip otherClip;
    public AudioClip other_Clip;
    AudioSource audioChange;
    int nummer;
    // Start is called before the first frame update
    void Start()
    {
        audioChange = GetComponent<AudioSource>();
        audioChange.Play();
        nummer = 0;
    }
    private static Audio_play instance = null;
    public static Audio_play Instance
    {
        get { return instance; }
    }

    private void Update()
    {
        if (audioChange.isPlaying == false && nummer == 0)
        {
            nummer++;
            audioChange.clip = otherClip;
            audioChange.Play();
        }

        if (audioChange.isPlaying == false && nummer == 1)
        {
            nummer++;
            audioChange.clip = other_Clip;
            audioChange.Play();
        }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        if (scene.name == "Hell")
        {
            Destroy(this.gameObject);
        }
    }
}
