using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level_control : MonoBehaviour
{
    public GameObject player;
    public GameObject PauseMenu;
    public GameObject UpgradeMenu;
    public GameObject m_LoseMenu;
    
    public LoseMenu m_LoseMenuScript;
    public GameObject m_WinMenu;
    public win_menu m_WinMenuScript;
    public RandomSpawner m_RandomSpawner;
    public static int enemy_kill_count;
    public bool GameIsPaused = false;
    public bool UpgradeActive = false;
    
    public float TimeScaleBefore;
    public enemy_hexagon HexagonScript;
    
    //music controls
    public AudioSource UpgradeMusic;
    public AudioSource WinMusic;
    public AudioSource LoseMusic;
    public AudioSource TutorialMusic;
    //

    
    void Start()
    { 
        player = GameObject.Find("Cubeman"); 
        
    }
    void Awake()
    {
        TimeScaleBefore = 1f;
        GameIsPaused = false;
    }
    

    // Update is called once per frame
    void Update()
    {
        
        if(Time.timeScale == 0f)
        {
            GameIsPaused = true;
            // m_RandomSpawner.PhaseMusic[0].Pause();
        }
        else
        {
            GameIsPaused = false;
            // if(m_RandomSpawner.PhaseMusic[0].isPlaying == false)
            // {
            //     m_RandomSpawner.PhaseMusic[0].Play();
            // }
            
        }
        
        if(player==null && GameIsPaused == false) //when player dies
        {
            Lose();
        } 



        if(player != null && Input.GetKeyDown(KeyCode.Escape) && UpgradeActive == false)
        {
            PauseGame();
        }
        
        // string enemycount = enemy_kill_count.ToString();
        // enemytext.text = enemycount;
        
        
        
    }

    void Lose()
    {
        Time.timeScale = 0f;  
        Debug.Log("game is paused, player is dead.");
        m_LoseMenu.SetActive(true);
        if(m_LoseMenuScript.score != null)
        {m_LoseMenuScript.UpdateScore(m_RandomSpawner.secondscount);}
        GameIsPaused = true;
        

        if(TutorialMusic != null)
        {   
            if(TutorialMusic.isPlaying == true)
            {
                TutorialMusic.Stop();
            }
        }
        else    
        {
            if(HexagonScript.BossMusic.isPlaying == true)
            {
                HexagonScript.BossMusic.Stop();
            }
            else if(m_RandomSpawner.PhaseMusic[0].isPlaying == true)
            {
                m_RandomSpawner.PhaseMusic[0].Pause();
            }
        }
        LoseMusic.Play();
    }

    public void Win()
    {   
        
        Time.timeScale = 0f;
        m_WinMenu.SetActive(true);
        m_WinMenuScript.UpdateScore(m_RandomSpawner.secondscount);
        GameIsPaused = true;
        m_RandomSpawner.PhaseMusic[0].Pause();
        WinMusic.Play();
    }

     public void CountEnemy()
     {
         enemy_kill_count++;
         Debug.Log("Enemies killed : " + enemy_kill_count);
     }

    public void PauseGame()
    {   
        if(GameIsPaused == false)
        { 
            TimeScaleBefore = Time.timeScale;
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
            Debug.Log("game is paused");
            GameIsPaused = true;
        }
        else
        {
            Time.timeScale = TimeScaleBefore;
            PauseMenu.SetActive(false);
            Debug.Log("game is unpaused");
            GameIsPaused = false;
        }
    }

    public void Upgrade()
    {
        if(GameIsPaused == false)
        { 
            m_RandomSpawner.PhaseMusic[0].Pause();
            UpgradeMusic.Play();
            TimeScaleBefore = Time.timeScale;
            Time.timeScale = 0f;
            UpgradeMenu.SetActive(true);
            Debug.Log("Ugrade Menu");
            GameIsPaused = true;
            UpgradeActive = true;
        }
        else
        {
         
            UpgradeMusic.Stop();
            Time.timeScale = TimeScaleBefore;
            UpgradeMenu.SetActive(false);
            Debug.Log("Ugrade Menu");
            GameIsPaused = false;
            UpgradeActive = false;
            if(m_RandomSpawner.phase != 4)
            {
                m_RandomSpawner.PhaseMusic[0].Play();
            }
        }
    }

    

    
}
