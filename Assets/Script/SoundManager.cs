//Author: Small Hedge Games
//Published: 12/04/2024

using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public enum SfxType {
    CLICK,
    FOOTSTEP,
    HURT,
    WIN,
    LOOSE,
    RECIVE
}

public enum MusicType {
    HOME,
    LEVEL1,
    LEVEL2
}

[ExecuteInEditMode]
public class SoundManager : MonoBehaviour {

    public static SoundManager Instance { get; private set; }

    [SerializeField] private SoundList[] sfxList;
    [SerializeField] private SoundList[] musicList;

    public AudioSource musicSource, sfxSource;
    public bool musicPlaying = true, sfxPlaying = true;

    private void Awake() {
        if (Application.isPlaying) {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                PlayMusic(MusicType.HOME, 1);
            }
            else {
                Destroy(gameObject);
            }
        }
    }


    private void Start() {

    }


    public static void PlaySFX(SfxType sound, float volume = 1) {
        AudioClip[] clips = Instance.sfxList[(int)sound].Sounds;
        AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];
        Instance.sfxSource.PlayOneShot(randomClip, volume);
    }




    public static void PlayMusic(MusicType music, float volume = 1) {
        AudioClip[] clips = Instance.musicList[(int)music].Sounds;
        AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];
        Instance.musicSource.clip = randomClip;
        Instance.musicSource.Play();
    }

    public void ToggleMusic() {
        musicSource.mute = !musicSource.mute;
        musicPlaying = !musicPlaying;
    }

    public void ToggleSFX() {
        sfxSource.mute = !sfxSource.mute;
        sfxPlaying = !sfxPlaying;
    }

    public void MusicVolume(float volume) {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume) {
        sfxSource.volume = volume;
    }

    public float GetMusicVolume() {
        return musicSource.volume;
    }

    public float GetSFXVolume() {
        return sfxSource.volume;
    }



#if UNITY_EDITOR
    private void OnEnable() {
        string[] sfxNames = Enum.GetNames(typeof(SfxType));
        string[] musicNames = Enum.GetNames(typeof(MusicType));
        Array.Resize(ref sfxList, sfxNames.Length);
        Array.Resize(ref musicList, musicNames.Length);
        for (int i = 0; i < sfxList.Length; i++)
            sfxList[i].name = sfxNames[i];
        for (int i = 0; i < musicList.Length; i++)
            musicList[i].name = musicNames[i];

    }
#endif
}

[Serializable]
public struct SoundList {
    public AudioClip[] Sounds { get => sounds; }
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] sounds;
}