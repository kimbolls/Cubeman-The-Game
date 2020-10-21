using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level_control : MonoBehaviour
{
    public GameObject player;
    public static int enemy_kill_count;
    public bool GameIsPaused = false;
    public Text enemytext;
    
    void Start()
    {
        player = GameObject.Find("Cubeman");
        enemy_kill_count = 0; 
        Debug.Log(enemy_kill_count); 
    }
    

    // Update is called once per frame
    void Update()
    {
        if(player==null && GameIsPaused == false) //when player dies
        {
            Lose();
        }  

        string enemycount = enemy_kill_count.ToString();
        enemytext.text = enemycount;
    }

    void Lose()
    {
        Time.timeScale = 0f;  
        Debug.Log("game is paused, player is dead.");
        GameIsPaused = true;
    }

    public void CountEnemy()
    {
        enemy_kill_count++;
        Debug.Log("Enemies killed : " + enemy_kill_count);
    }

    
}
