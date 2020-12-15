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
    public AudioSource slowmoin;
    public AudioSource slowmoout;
    public AudioSource overheatIn;

    public GameObject PProcess;
    public GameObject gun1;
    
    void Start()
    {
       
        
        Debug.Log("Start");
        
    }

    void Awake()
    {
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {   
        if(gun1 == null)
        {
            Debug.Log("Gun 1 is null");
            gun1 = GameObject.FindGameObjectWithTag("player_gun");
            shooting = gun1.GetComponent<gun1_shooting>();
            Debug.Log("gun1 is now assigned");
        }
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
            && OverHeatStatus == false  && Time.timeScale != 0f)
        {   
            OverHeatTimer += 4f;
            player_Ui.SetMaxOh(OverHeatTimer);
            NormalAtkSpd = shooting.attackrate;
            shooting.attackrate += OverHeatSpd;
            attributes.current_mp -= 50f;
            overheatIn.Play();
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
            slowmoin.Play();
            
            Time.timeScale = 0.5f;
            PProcess.SetActive(true);
            SlowMoTrue = true;
            
        }
        else if(SlowMoTrue == true && Time.timeScale != 0f)
        {
            slowmoout.Play();
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
