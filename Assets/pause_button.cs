using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_button : MonoBehaviour
{
    // Start is called before the first frame update
    public level_control LevelControl;

    public GameObject PauseMenu;
    
    
    
    public void ResumeGame()
    {
        LevelControl.PauseGame();  
    }

    public void Menu()
    {
        // level_control.GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
