using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_ui : MonoBehaviour
{
    public Slider hpslider;
    public Slider mpslider;

    //hp
    public void SetMaxHP(float health)
    {
        hpslider.maxValue = health;
        hpslider.value = health;
    }

    public void SetHP(float health)
    {
        hpslider.value = health;
    }

    // mana

    public void SetMaxMana(float mana)  // set slider value  for mana
    {
        mpslider.maxValue = mana; //set max value
        mpslider.value = mana; //set current value
    }

    public void Setmana(float mana)  // set slider value, this will updated every frame
    {
       mpslider.value = mana; //update current value of mana
    }
}
