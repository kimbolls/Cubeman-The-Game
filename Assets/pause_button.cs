using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_button : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject level_control_object;

    public GameObject PauseMenu;
    
    void Start()
    {
        level_control level = level_control_object.GetComponent<level_control>(); 
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        Debug.Log("game is unpaused");
        
    }

    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
