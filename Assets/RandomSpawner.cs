using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    public Transform[] SpawnPoint;
    public float timer = 0.0f;
    public GameObject enemy_regular;
    public GameObject HpBoost;
    
    
    int index;
    int i,j,seconds;

    void Start()
    {
        index = SpawnPoint.Length;
        InvokeRepeating("Spawn_regular",1f,2f);
        InvokeRepeating("Spawn_HpBoost",1f,5f);
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int) timer;
        
        // if(timer % 2 == 0 && timer != 0)
        // {
        //     Spawn_regular();
        //     Debug.Log("Spawn enemy");
        // }
    }


    int Randomize(int num)
    {
        num = Random.Range(0,index);
        return num;
    }

    void Spawn_regular()
    {
        i = Randomize(i);
        GameObject enemy_regular_spawn = Instantiate(enemy_regular,SpawnPoint[i].position,Quaternion.identity);
    }

    void Spawn_HpBoost()
    {
        j = Randomize(j);
        GameObject HpBoostSpawn = Instantiate(HpBoost,SpawnPoint[j].position,Quaternion.identity);
    }

    


    
}
