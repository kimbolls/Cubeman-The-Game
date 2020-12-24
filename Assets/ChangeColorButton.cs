using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorButton : MonoBehaviour
{   
    public GameObject player;
    public cube_attributes CubeAttributes;
    public color_selection Color_Selection;
    public Color SelectedColor;

    public Color[] ColorOption;
    
    void Start()
    {
        player = GameObject.Find("Cubeman");
        CubeAttributes = player.GetComponent<cube_attributes>();
        Color_Selection = player.GetComponent<color_selection>();
    }

    void SaveColor(Color SelectedColor)
    {
        Color_Selection.SetColor(SelectedColor.r,SelectedColor.g,SelectedColor.b,SelectedColor.a);
        CubeAttributes.m_SpriteRenderer.color = SelectedColor;
    }

    public void SetColorDefault()
    {
        SelectedColor = ColorOption[0];
        SaveColor(SelectedColor);
    }

    public void SetColor1()
    {
        SelectedColor = ColorOption[1];
        SaveColor(SelectedColor);
    }

    public void SetColor2()
    {
        SelectedColor = ColorOption[2];
        SaveColor(SelectedColor);
    }

    public void SetColor3()
    {
        SelectedColor = ColorOption[3];
        SaveColor(SelectedColor);
    }

    

    
}
