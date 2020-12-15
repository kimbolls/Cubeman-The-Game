using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgrade_menu : MonoBehaviour
{
    public level_control LevelControl;

    //---------------------- < player >
    public GameObject Cuby;
    public cube_attributes Stats;
    public cube_abilities Abilities;
    public cube_movement Movement;
    //-------------------------- < others >
    public gun1_shooting Gun1;
    public gun1_projectile Gun1Projectile;
    public GameObject HPRegenUI;
    public GameObject AtkSpdUI;
    public Text HPRegenValue;
    public Text AtkSpdValue;

    int bonusAtk = 0,bonusHP = 0;

    void Start()
    {
        GameObject Gun1_object = GameObject.FindGameObjectWithTag("player_gun");
        Gun1 = Gun1_object.GetComponent<gun1_shooting>();  
    }


    void CloseMenu()
    {
        LevelControl.Upgrade();
    }

    public void IncreaseAtkSpd()
    {
        if(AtkSpdUI.activeSelf == false)
        {
            AtkSpdUI.SetActive(true);
        }
        bonusAtk += 1;
        string AtkSpdCount = bonusAtk.ToString();
        AtkSpdValue.text = AtkSpdCount;
        Gun1.attackrate += 1f;
        CloseMenu();
    }

    public void IncreaseHpRegen()
    {
        if(HPRegenUI.activeSelf == false)
        {
            HPRegenUI.SetActive(true);
        }
        bonusHP += 1;
        string BonusHPCount = bonusHP.ToString();
        HPRegenValue.text = BonusHPCount;
        Stats.regen_hp += 2f;
        CloseMenu();
    }

    public void IncreaseJumpCharge()
    {
        Movement.MaxJumpCharge += 1;
        CloseMenu();
    }

    
    
}
