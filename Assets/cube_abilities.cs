using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_abilities : MonoBehaviour
{
    public Rigidbody2D rb;
    public cube_attributes attributes;
    public level_control level;
    public bool SlowMoTrue = false;
    public float TimeScale;
    public float MPRegen = 10f;
    public float SlowMotionMP = 10f;
    
    void Start()
    {
        
    }

    void Awake()
    {
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {   
        TimeScale = Time.timeScale;
        if(Input.GetKeyDown("e"))
        {
            SlowMo();
        }

        MPDegen();
        MPLimiters();

        if(SlowMoTrue == true && attributes.current_mp <= 0)
        {
            SlowMo();
        }
        

    }

    void Dash()
    {
        
    }

    void SlowMo()
    {
        if(SlowMoTrue == false && attributes.current_mp >= SlowMotionMP && Time.timeScale != 0f)
        {   
            // slowmoin.Play();
            // slowmofilter.enabled = true;
            Time.timeScale = 0.5f;
            SlowMoTrue = true;
            
        }
        else if(SlowMoTrue == true && Time.timeScale != 0f)
        {
            // slowmoout.Play();
            // slowmofilter.enabled = false;
            Time.timeScale = 1f; 
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
