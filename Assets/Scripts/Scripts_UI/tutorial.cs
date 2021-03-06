﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour
{
    
    public GameObject m_TutorialMenu;
    public GameObject m_MovementMenu;
    public GameObject m_AbilitiesMenu;
    public GameObject m_GameplayMenu;
    public GameObject m_ShootingMenu;
    
    public GameObject ActiveMenu;
    public bool MenuHidden = false;

    public void Start()
    {   
        
        m_TutorialMenu.SetActive(true);
        ActiveMenu = m_TutorialMenu;
    }
    public void Back()
    {
        ActiveMenu.SetActive(false);
        m_TutorialMenu.SetActive(true);
        ActiveMenu = m_TutorialMenu;
    }


    public void HideMenu()
    {
        if(MenuHidden == false)
        {
            ActiveMenu.SetActive(false);
            MenuHidden = true;
        }
        else
        {
            ActiveMenu.SetActive(true);
            MenuHidden = false;
        }
    }

    public void SkipHelp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    
    public void MovementMenu()
    {
        m_TutorialMenu.SetActive(false);
        m_MovementMenu.SetActive(true);
        ActiveMenu = m_MovementMenu;
    }
    public void AbilitiesMenu()
    {
        m_TutorialMenu.SetActive(false);
        m_AbilitiesMenu.SetActive(true);
        ActiveMenu = m_AbilitiesMenu;
    }
    public void ShootingMenu()
    {
        m_TutorialMenu.SetActive(false);
        m_ShootingMenu.SetActive(true);
        ActiveMenu = m_ShootingMenu;
    }
    public void GameplayMenu()
    {
        m_TutorialMenu.SetActive(false);
        m_GameplayMenu.SetActive(true);
        ActiveMenu = m_GameplayMenu;
    }


}
