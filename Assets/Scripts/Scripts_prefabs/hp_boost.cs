using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_boost : MonoBehaviour
{
    public float HealValue;
    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        cube_attributes player = hitInfo.gameObject.GetComponent<cube_attributes>();
        if(player != null)
        {
            player.HealHP(HealValue);
            Destroy(gameObject);
        }
    }
}
