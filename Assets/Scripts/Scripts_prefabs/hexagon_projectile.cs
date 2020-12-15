using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hexagon_projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    public Rigidbody2D rb;

    void Start()
    {
        Destroy(gameObject,5f);
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        //  enemy_attributes enemy = hitInfo.gameObject.GetComponent<enemy_attributes>();
        //  if(enemy != null)
        //  {
        //      enemy.TakeDamage(damage);

        //  }

        cube_attributes player = hitInfo.gameObject.GetComponent<cube_attributes>();
        if(player != null)
        {
            player.TakeDamage(damage);
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
        Destroy(gameObject);
        // Destroy(impact, 0.5f);
        }
        
    }
}
