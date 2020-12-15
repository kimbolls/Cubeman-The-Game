using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject SettingsMenu;
    public AudioMixer audioMixer;
    public GameObject QuitConfirm;

    void Start()
    {
        Time.timeScale = 1f;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings()
    {
        mainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
        QuitConfirm.SetActive(true);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }
}
