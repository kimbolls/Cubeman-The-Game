using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun1_projectile : MonoBehaviour
{
    //public GameObject impact;
    public int damage;
    public GameObject Particle;
    public SpriteRenderer Sprite;

    void Start()
    {
         
        Destroy(gameObject,5f);
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
         enemy_attributes enemy = hitInfo.gameObject.GetComponent<enemy_attributes>();
         if(enemy != null)
         {
            enemy.TakeDamage(damage);

         }

         enemy_hexagon boss = hitInfo.gameObject.GetComponent<enemy_hexagon>();
         if(boss != null)
         {
            boss.TakeDamage(damage);
            
         }

         

        // barrierdetails barrier = hitInfo.gameObject.GetComponent<barrierdetails>();
        // if(barrier != null)
        // {
        //     barrier.TakeDamage(damage);
        // }

        // //Debug.Log(hitInfo.gameObject.name);

        if(hitInfo.gameObject.tag != "bullets") // destroy if collide with anything/dont need?
        {
        // impact = Instantiate(impact, transform.position, Quaternion.identity); *create effect upon collide*
        GameObject ParticleObject = Instantiate(Particle,transform.position,Quaternion.identity);
        ParticleSystem Effect = ParticleObject.GetComponent<ParticleSystem>();
        var main = Effect.main;
        main.startColor = Sprite.color;
        Destroy(gameObject);

        // Destroy(impact, 0.5f);
        }
        
    }
}
