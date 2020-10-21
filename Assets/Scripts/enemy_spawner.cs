using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    public GameObject enemy_regular;
    void Start()
    {
        InvokeRepeating("enemy_regularSpawn",1f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


void enemy_regularSpawn()
{
    GameObject enemy_regular_spawn = Instantiate(enemy_regular,transform.position,Quaternion.identity);

}

}

