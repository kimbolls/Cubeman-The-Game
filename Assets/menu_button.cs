using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_button : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SettingsMenu;


    public void goToMain()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }
}
