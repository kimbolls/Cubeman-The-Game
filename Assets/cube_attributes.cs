using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_attributes : MonoBehaviour
{
    public float max_hp;
    public float current_hp;

    public float max_mp;
    public float current_mp;
    public SpriteRenderer m_SpriteRenderer;
    public Color m_DefaultColor;
    public Color m_DamagedColor;
    public GameObject floatingnum;

    public player_ui player_Ui;
    private IEnumerator coroutine;
    

    void Start()
    {
        current_hp = max_hp;
        current_mp = max_mp;
        player_Ui.SetMaxHP(max_hp);
        player_Ui.SetMaxMana(max_mp);
        

        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {   
         player_Ui.SetHP(current_hp);  // update player hp with UI 
         player_Ui.Setmana(current_mp);
        if(current_hp <= 0)
        {
            
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        current_hp -= damage;
        GameObject FloatNumbers = Instantiate(floatingnum,transform.position,Quaternion.identity);
        FloatingHandler FloatScript = FloatNumbers.GetComponent<FloatingHandler>();
        FloatScript.DisplayDamage(damage);
        coroutine = Damaged(0.2f);
        StartCoroutine(coroutine);
        
    }

    private IEnumerator Damaged(float sec)
    {
        Debug.Log("take damge");
        m_SpriteRenderer.color = m_DamagedColor;
        yield return new WaitForSeconds(sec);
        m_SpriteRenderer.color = m_DefaultColor;
        
    }

    void Die()
    {
        current_hp = 0;
        Destroy(gameObject);
    }
    
    public void HealHP(float Heal)
    {
        current_hp += Heal;
        if(current_hp >= max_hp)
        {
            current_hp = max_hp;
        }
    }
}
