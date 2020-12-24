using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class color_selection : MonoBehaviour
{
    public cube_attributes Cube_Attributes;
    public GameObject Player;
    
    //color
    // public float rValue,Gvalue,Bvalue,aValue;
    public Color CubyColor;

    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            Player = GameObject.Find("Cubeman");
            Cube_Attributes = Player.GetComponent<cube_attributes>();
            LoadColor();
            
        }
    }

    public void SetColor(float r,float g,float b,float a)
    {
        PlayerPrefs.SetFloat("rValue", r);
        PlayerPrefs.SetFloat("gValue", g);
        PlayerPrefs.SetFloat("bValue", b);
        PlayerPrefs.SetFloat("aValue", a);
        
    }

    public void LoadColor()
    {
        CubyColor = new Color(
            PlayerPrefs.GetFloat("rValue"),
            PlayerPrefs.GetFloat("gValue"),
            PlayerPrefs.GetFloat("bValue"),
            PlayerPrefs.GetFloat("aValue")
        );

        Cube_Attributes.m_SpriteRenderer.color = CubyColor;
        Cube_Attributes.m_DefaultColor = CubyColor;
    }

    
}
