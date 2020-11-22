using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Gun1.attackrate += 1f;
        CloseMenu();
    }

    public void IncreaseHpRegen()
    {
        Stats.regen_hp += 2f;
        CloseMenu();
    }

    public void IncreaseJumpCharge()
    {
        Movement.MaxJumpCharge += 1;
        CloseMenu();
    }

    
    
}
