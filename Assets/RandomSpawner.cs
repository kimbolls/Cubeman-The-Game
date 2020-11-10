using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpawner : MonoBehaviour
{

    public Transform[] SpawnPoint;
    public float timer = 0.0f;
    public GameObject enemy_regular;
    public GameObject enemy_sniper;
    public GameObject HpBoost;
    public GameObject[] EnemyAlive;
    // public level_control LevelControl;
    public Text enemytext;
    public int phase = 0;
    public bool spawnstatus = false;
    public float Phase1Timer,Phase2Timer;

    // public float spawndelay;
    // public float spawninterval;
     
    int index,i,j,seconds;

    void Start()
    {
        index = SpawnPoint.Length;
    }

    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int) timer;
        string secondscount = seconds.ToString();
        enemytext.text = secondscount;
        Phasecontrol();
        // if(timer % 2 == 0 && timer != 0)
        // {
        //     Spawn_Regular();
        //     Debug.Log("Spawn enemy");
        // }
    }


    int Randomize(int num)
    {
        num = Random.Range(0,index);
        return num;
    }

    void Spawn_Regular()
    {
        i = Randomize(i);
        GameObject enemy_regular_spawn = Instantiate(enemy_regular,SpawnPoint[i].position,Quaternion.identity);
    }

    void Spawn_Sniper()
    {
        i = Randomize(i);
        GameObject enemy_sniper_spawn = Instantiate(enemy_sniper,SpawnPoint[i].position,Quaternion.identity);
    }

    void Spawn_HpBoost()
    {
        j = Randomize(j);
        GameObject HpBoostSpawn = Instantiate(HpBoost,SpawnPoint[j].position,Quaternion.identity);
    }

    void CountEnemyAlive()
    {
        EnemyAlive = GameObject.FindGameObjectsWithTag("enemy");
        if(EnemyAlive.Length == 0)
        {
           //Debug.Log("no enemies found");
        }
    }

    void Phasecontrol()
    {
        CountEnemyAlive();
        if(phase == 1)
        {
            Phase1Timer -= Time.deltaTime;
            if(Phase1Timer <= 0){Phase1Timer = 0;}
        }
        else if(phase == 2)
        {
            Phase2Timer -= Time.deltaTime;
            if(Phase2Timer <= 0){Phase2Timer = 0;}
        }
        
        if(spawnstatus == false)
        {
            if(seconds == 4 && phase == 0)
            {
                InvokeRepeating("Spawn_Regular",1f,3f);
                InvokeRepeating("Spawn_HpBoost",15f,30f);
                spawnstatus = true;
                phase = 1;
            }
            else if(Phase1Timer <= 0 && phase == 1 && EnemyAlive.Length == 0)
            {
                
                InvokeRepeating("Spawn_Regular",5f,2f);
                InvokeRepeating("Spawn_Sniper",6f,6f);
                spawnstatus = true;
                phase = 2;
            }
        }
        else if(spawnstatus == true)
        {
            if(Phase1Timer <= 0 && phase == 1)
            {
                CancelInvoke("Spawn_Regular");
                spawnstatus = false;
            }
            else if(Phase2Timer <= 0 && phase == 2)
            {
                CancelInvoke("Spawn_Regular");
                spawnstatus = false;
            }
        }




    }


    
}
