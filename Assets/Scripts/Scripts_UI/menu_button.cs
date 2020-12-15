using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_button : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SettingsMenu;
    public AudioSource ClickSound;


    public void goToMain()
    {
        ClickSound.Play();
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }
}
