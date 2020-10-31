using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_ui : MonoBehaviour
{
    public Slider hpslider;
    public void SetMaxHP(float health)
    {
        hpslider.maxValue = health;
        hpslider.value = health;
    }

    public void SetHP(float health)
    {
        hpslider.value = health;
    }
}
