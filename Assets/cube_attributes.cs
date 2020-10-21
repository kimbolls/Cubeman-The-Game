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
    public Color m_CurrentColor;
    public Color m_NewColor;

    private IEnumerator coroutine;
    

    void Start()
    {
        current_hp = max_hp;
        current_mp = max_mp;

        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        if(current_hp <= 0)
        {
            
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        current_hp -= damage;
        
        coroutine = Damaged(0.4f);
        StartCoroutine(coroutine);
        
    }

    private IEnumerator Damaged(float sec)
    {
        Debug.Log("take damge");
        m_SpriteRenderer.color = m_NewColor;
        yield return new WaitForSeconds(sec);
        m_SpriteRenderer.color = m_CurrentColor;
        
    }

    void Die()
    {
        current_hp = 0;
        Destroy(gameObject);
    }
}
