using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip BGM_Intro;
    public AudioClip BGM_Play;
    public AudioClip BGM_Result;

    private AudioSource audioSource;

    void Awake()
    {
        // 싱글톤 설정
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 이동해도 유지
        }
        else
        {
            Destroy(gameObject); // 중복 방지
            return;
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.playOnAwake = false;
    }

    void Start()
    {
        PlayBGM(SceneManager.GetActiveScene().name);
        SceneManager.sceneLoaded += OnSceneLoaded; // 씬 변경 시 감지
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) { PlayBGM(scene.name); }

    void PlayBGM(string sceneName)
    {
        AudioClip clipToPlay = null;

        switch (sceneName)
        {
            case "MainScene":
                clipToPlay = BGM_Intro;
                break;
            case "PlayScene":
                clipToPlay = BGM_Play;
                break;
            case "ResultScene":
                clipToPlay = BGM_Result;
                break;
            default:
                clipToPlay = null;
                break;
        }

        if (clipToPlay != null)
        {
            if (audioSource.clip != clipToPlay)
            {
                audioSource.clip = clipToPlay;
                audioSource.Play();
            }
        }
        else { audioSource.Stop(); }
    }
}
