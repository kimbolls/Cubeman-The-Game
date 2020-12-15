using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit_confirm : MonoBehaviour
{
    public GameObject QuitConfirm;

    public void Quit()
    {
        Application.Quit();
    }

    public void Cancel()
    {
        QuitConfirm.SetActive(false);
    }
    
}
