using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button musicOn, musicOff, sfxOn, sfxOff;

    public Slider musicSlider, sfxSlider;

    void Start() {
        float musicVolume = SoundManager.Instance.GetMusicVolume();
        float sfxVolume = SoundManager.Instance.GetSFXVolume();

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;

        if (SoundManager.Instance.musicPlaying) {
            musicOn.gameObject.SetActive(true);
            musicOff.gameObject.SetActive(false);
        }
        else {
            musicOn.gameObject.SetActive(false);
            musicOff.gameObject.SetActive(true);
        }

        if (SoundManager.Instance.sfxPlaying) {
            sfxOn.gameObject.SetActive(true);
            sfxOff.gameObject.SetActive(false);
        }
        else {
            sfxOn.gameObject.SetActive(false);
            sfxOff.gameObject.SetActive(true);
        }
    }

    public void ToggleMusic() {
        SoundManager.Instance.ToggleMusic();
        SoundManager.PlaySFX(SfxType.CLICK);
        if (SoundManager.Instance.musicPlaying) {
            musicOn.gameObject.SetActive(true);
            musicOff.gameObject.SetActive(false);
        }
        else {
            musicOn.gameObject.SetActive(false);
            musicOff.gameObject.SetActive(true);
        }
    }

    public void ToggleSFX() {
        SoundManager.Instance.ToggleSFX();
        SoundManager.PlaySFX(SfxType.CLICK);
        if (SoundManager.Instance.sfxPlaying) {
            sfxOn.gameObject.SetActive(true);
            sfxOff.gameObject.SetActive(false);
        }
        else {
            sfxOn.gameObject.SetActive(false);
            sfxOff.gameObject.SetActive(true);
        }
    }

    public void MusicVolume() {
        SoundManager.Instance.MusicVolume(musicSlider.value);
    }

    public void SFXVolume() {
        SoundManager.Instance.SFXVolume(sfxSlider.value);
    }


    public void ExitButton() {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartGame() {
        SceneManager.LoadScene("GamePlay");
    }

    public void ClickSound() {
        SoundManager.PlaySFX(SfxType.CLICK);
    }
}
