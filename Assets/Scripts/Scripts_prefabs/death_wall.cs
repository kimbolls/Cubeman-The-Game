using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_wall : MonoBehaviour
{
    public int damage;
    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        //  enemy enemy = hitInfo.gameObject.GetComponent<enemy>();
        //  if(enemy != null)
        //  {
        //      enemy.TakeDamage(damage);

        // }

        cube_attributes player = hitInfo.gameObject.GetComponent<cube_attributes>();
        if(player != null)
        {
            player.TakeDamage(damage);
            player.Die();
        }

        // barrierdetails barrier = hitInfo.gameObject.GetComponent<barrierdetails>();
        // if(barrier != null)
        // {
        //     barrier.TakeDamage(damage);
        //}

        // //Debug.Log(hitInfo.gameObject.name);

        if(hitInfo.gameObject.tag != "bullets") // destroy if collide with anything/dont need?
        {
        // impact = Instantiate(impact, transform.position, Quaternion.identity); *create effect upon collide*
        Destroy(gameObject);
        // Destroy(impact, 0.5f);
        }
        
    }
}
