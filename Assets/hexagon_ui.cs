using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hexagon_ui : MonoBehaviour
{
    // Start is called before the first frame update
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
