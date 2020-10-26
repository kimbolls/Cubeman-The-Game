using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeChanger : MonoBehaviour
{

    public Slider volumeslider;
    
    public void VolumeUp()
    {
        volumeslider.value = volumeslider.value + 10;
    }

    public void VolumeDown()
    {
        volumeslider.value = volumeslider.value - 10;
    }
}
