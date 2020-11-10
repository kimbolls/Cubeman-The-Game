using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_button : MonoBehaviour
{
    // Start is called before the first frame update
    public level_control level_control;

    public GameObject PauseMenu;
    
    
    
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        Debug.Log("game is unpaused");
        
    }

    public void Menu()
    {
        // level_control.GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
