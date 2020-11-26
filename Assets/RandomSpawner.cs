using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpawner : MonoBehaviour
{

    public Transform[] SpawnPoint;
    public GameObject[] platformdestroy;
    public float timer = 0.0f;
    public GameObject enemy_regular;
    public GameObject enemy_sniper;
    public GameObject enemy_tank;
    public GameObject HpBoost;
    public GameObject[] EnemyAlive;
    public level_control LevelControl;
    public Text enemytext;
    public int phase = 0;
    public bool spawnstatus = false;
    public float Phase1Timer,Phase2Timer,Phase3Timer;
    public Transform HexagonSpawn;
    public GameObject HexagonBoss;

    // public float spawndelay;
    // public float spawninterval;
     //
    int index,i,j,seconds;
    public string secondscount;
    // music controls

    public AudioSource[] PhaseMusic;
    

    //

    void Start()
    {
        index = SpawnPoint.Length;
    }

    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int) timer;
        secondscount = seconds.ToString();
        // enemytext.text = secondscount;
        Phasecontrol();

        switch(phase)
        {
            case 1:
                enemytext.text = "Phase 1";
                break;
            case 2:
                enemytext.text = "Phase 2";
                break;
            case 3:
                enemytext.text = "Phase 3";
                break;
            case 4:
                enemytext.text = "Boss Phase";
                break;
            default:
                enemytext.text = "Get Ready...";
                break;
   
        }
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

    void Spawn_Tank()
    {
        i = Randomize(i);
        GameObject enemy_tank_spawn = Instantiate(enemy_tank,SpawnPoint[i].position,Quaternion.identity);
    }

    void Spawn_Hexagon()
    {
       //HexagonBoss = Instantiate(HexagonBoss,HexagonSpawn.position,Quaternion.identity);
        Destroy(platformdestroy[0],0f);
        Destroy(platformdestroy[1],0f);
        Destroy(platformdestroy[2],0f);
        HexagonBoss.SetActive(true);
        
       
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
        else if(phase == 3)
        {
            Phase3Timer -= Time.deltaTime;
            if(Phase3Timer <= 0){Phase3Timer = 0;}
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
                LevelControl.Invoke("Upgrade",3f);
                InvokeRepeating("Spawn_Regular",5f,2f);
                InvokeRepeating("Spawn_Sniper",6f,4f);
                spawnstatus = true;
                phase = 2;
            }
            else if(Phase2Timer <= 0 && phase == 2 && EnemyAlive.Length ==0)
            {
                LevelControl.Invoke("Upgrade",3f);
                InvokeRepeating("Spawn_Regular",5f,2f);
                InvokeRepeating("Spawn_Sniper",6f,4f);
                InvokeRepeating("Spawn_Tank",8f,8f);
                spawnstatus = true;
                phase = 3;
            }
            else if(Phase3Timer <= 0 && phase == 3 && EnemyAlive.Length == 0)
            {
                LevelControl.Invoke("Upgrade",3f);
                Invoke("Spawn_Hexagon",5f);
                spawnstatus = true;
                phase = 4;
                PhaseMusic[0].Stop();
                
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
                CancelInvoke("Spawn_Sniper");
                spawnstatus = false;
            }
            else if(Phase3Timer <= 0 && phase == 3)
            {
                CancelInvoke("Spawn_Regular");
                CancelInvoke("Spawn_Sniper");
                CancelInvoke("Spawn_Tank");
                spawnstatus = false;
            }
        }




    }


    
}
