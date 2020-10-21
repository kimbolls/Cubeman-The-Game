using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_attributes : MonoBehaviour
{
    public float max_hp;
    public float current_hp;
    public bool alive_status = true;
    public GameObject myLevel;

    public enemy_regular_shooting shooting;

    public level_control level;

    

    void Start()
    {
        current_hp = max_hp;
        level = myLevel.GetComponent<level_control>();
        
    }

   
    void Update()
    {
        if(current_hp <= 0 && alive_status == true)
        { 
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        current_hp -= damage;
        // add colour change
    }

    void Die()
    {
        Destroy(shooting.Gun);
        current_hp = 0;
        level.CountEnemy();
        alive_status = false;
        Destroy(gameObject);
    }
}
