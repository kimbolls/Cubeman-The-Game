using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_abilities : MonoBehaviour
{
    public Rigidbody2D rb;
    public cube_attributes attributes;
    public gun1_shooting shooting;
    public level_control level;
    public player_ui player_Ui;
    public bool SlowMoTrue = false;
    public float TimeScale;
    public float MPRegen = 10f;
    public float SlowMotionMP = 15f;
    public float OverHeatSpd; 
    public bool OverHeatStatus = false;
    public float OverHeatTimer = 0;
    public float NormalAtkSpd;  
    public float CurrentAtkSpd;

    public GameObject PProcess;
    
    void Start()
    {
        GameObject gun1 = GameObject.FindGameObjectWithTag("player_gun");
        shooting = gun1.GetComponent<gun1_shooting>();
        
    }

    void Awake()
    {
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {   
        CurrentAtkSpd = shooting.attackrate;
        TimeScale = Time.timeScale;
        if(Input.GetKeyDown("e"))
        {
            SlowMo();
        }

        
        OverHeat();
        MPDegen();
        MPLimiters();

        if(SlowMoTrue == true && attributes.current_mp <= 0)
        {
            SlowMo();
        }
        

    }

    void OverHeat()
    {   
        
        
        player_Ui.SetOh(OverHeatTimer);
        
        if(Input.GetKeyDown("q") && attributes.current_mp >= 50f 
            && OverHeatStatus == false)
        {   
            OverHeatTimer += 4f;
            player_Ui.SetMaxOh(OverHeatTimer);
            NormalAtkSpd = shooting.attackrate;
            shooting.attackrate += OverHeatSpd;
            attributes.current_mp -= 50f;
            OverHeatStatus = true;
        }

        if(OverHeatStatus == true)
        {
            PProcess.SetActive(true);
            OverHeatTimer -= Time.deltaTime;
            if(OverHeatTimer <= 0)
            {
                OverHeatTimer = 0;
                shooting.attackrate = NormalAtkSpd;
                PProcess.SetActive(false);
                OverHeatStatus = false;
            }
        }


    }

    void SlowMo()
    {
        if(SlowMoTrue == false && attributes.current_mp >= SlowMotionMP && Time.timeScale != 0f)
        {   
            // slowmoin.Play();
            // slowmofilter.enabled = true;
            Time.timeScale = 0.5f;
            PProcess.SetActive(true);
            SlowMoTrue = true;
            
        }
        else if(SlowMoTrue == true && Time.timeScale != 0f)
        {
            // slowmoout.Play();
            // slowmofilter.enabled = false;
            Time.timeScale = 1f; 
            PProcess.SetActive(false);
            SlowMoTrue = false;   
        }
    }

    void MPDegen()
    {
        
        if(SlowMoTrue == true)
        {
            attributes.current_mp -= SlowMotionMP * Time.deltaTime;
        }
        else
        {
            attributes.current_mp += MPRegen * Time.deltaTime;
        }
    }

    void MPLimiters()
    {
        if(attributes.current_mp >= attributes.max_mp)
        {
            attributes.current_mp = attributes.max_mp; //prevent over max
        }
        if(attributes.current_mp <= 0)
        {
            attributes.current_mp = 0; // prevent negative value
        }
    }



}
