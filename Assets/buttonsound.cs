using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonsound : MonoBehaviour
{
    public AudioSource HoverSound;
    public AudioSource ClickSound;

    public void Click()
    {
        ClickSound.Play();
    }

    public void Hover()
    {
        HoverSound.Play();
    }
}
