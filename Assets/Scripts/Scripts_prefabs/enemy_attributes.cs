using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_attributes : MonoBehaviour
{
    public float max_hp;
    public float current_hp;
    public bool alive_status = true;
    public GameObject myLevel;
    public GameObject floatingnum;

    public enemy_regular_shooting shooting;

    public level_control level;
    public enemy_ui enemy_Ui;
    public AudioSource enemydamagesound;

    public GameObject DeathParticles;

    

    void Start()
    {
        current_hp = max_hp;
        enemy_Ui.SetMaxHP(max_hp);
        level = myLevel.GetComponent<level_control>();
    }

   
    void Update()
    {   
        enemy_Ui.SetHP(current_hp);
        if(current_hp <= 0 && alive_status == true)
        { 
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        current_hp -= damage;
        enemydamagesound.Play();
        GameObject FloatNumbers = Instantiate(floatingnum,transform.position,Quaternion.identity);
        FloatingHandler FloatScript = FloatNumbers.GetComponent<FloatingHandler>();
        FloatScript.DisplayDamage(damage);
    }

    void Die()
    {
        Destroy(shooting.Gun);
        enemydamagesound.Play();
        current_hp = 0;
        GameObject DeathEffects = Instantiate(DeathParticles,transform.position,Quaternion.identity);
        level.CountEnemy();
        alive_status = false;
        Destroy(gameObject);
    }
}
