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
    public float Phase1Timer,Phase2Timer,Phase3Timer,Phase4Timer,Phase5Timer;
    public Transform HexagonSpawn;
    public GameObject HexagonBoss;
    public GameObject DifficultyMenuObj;
    public difficulty_menu Difficulty_Menu;
    public difficulty_menu.DifficultyEnum Difficulty;
    public difficulty_indicator DifficultyIndicator;
    public float RG,SN,TK;

    // public float spawndelay;
    // public float spawninterval;
    int index,i,j,seconds;
    public string secondscount;
    bool DifficultyBool = false;
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
        DifficultyReflect();

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
                enemytext.text = "Phase 4";
                break;
            case 5:
                enemytext.text = "Phase 5";
                break;
            case 6:
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

    void DifficultyReflect()
    {
        if(Difficulty == difficulty_menu.DifficultyEnum.Easy)
        { 
            DifficultyIndicator.EasyIcon.SetActive(true);
            DifficultyIndicator.DifficultyText.text = "Easy";
        }
        else if (Difficulty == difficulty_menu.DifficultyEnum.Normal)
        {
            DifficultyIndicator.EasyIcon.SetActive(false);
            DifficultyIndicator.NormalIcon.SetActive(true);
            DifficultyIndicator.DifficultyText.text = "Normal";
        }
        else if (Difficulty == difficulty_menu.DifficultyEnum.Hard)
        {
            DifficultyIndicator.EasyIcon.SetActive(false);
            DifficultyIndicator.HardIcon.SetActive(true);
            DifficultyIndicator.DifficultyText.text = "Hard";
        }
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
        else if(phase == 4)
        {
            Phase4Timer -= Time.deltaTime;
            if(Phase4Timer <= 0){Phase4Timer = 0;}
        }
        else if(phase == 5)
        {
            Phase5Timer -= Time.deltaTime;
            if(Phase5Timer <= 0){Phase5Timer = 0;}
        }
        
        if(spawnstatus == false)
        {
            if(seconds == 1 && DifficultyBool == false)
            {
                LevelControl.DifficultySet();
                DifficultyBool = true;
            }
            if(seconds == 4 && phase == 0)
            {
                InvokeRepeating("Spawn_Regular",1f,3f);
                InvokeRepeating("Spawn_HpBoost",15f,25f);
                spawnstatus = true;
                phase = 1;
            }
            else if(Phase1Timer <= 0 && phase == 1 && EnemyAlive.Length == 0)
            {
                if(Difficulty == difficulty_menu.DifficultyEnum.Easy)
                {
                    RG = 3.5f;
                    SN = 4.5f;
                }
                else if(Difficulty == difficulty_menu.DifficultyEnum.Normal)
                {
                    RG = 2.5f;
                    SN = 4.5f;
                }
                else if(Difficulty == difficulty_menu.DifficultyEnum.Hard)
                {
                    RG = 2f;
                    SN = 3f;
                }
                LevelControl.Invoke("Upgrade",3f);
                InvokeRepeating("Spawn_Regular",5f,RG);
                InvokeRepeating("Spawn_Sniper",6f,SN);
                spawnstatus = true;
                phase = 2;
            }
            else if(Phase2Timer <= 0 && phase == 2 && EnemyAlive.Length ==0)
            {
                if(Difficulty == difficulty_menu.DifficultyEnum.Easy)
                {
                    RG = 3f;
                    SN = 4f;
                }
                else if(Difficulty == difficulty_menu.DifficultyEnum.Normal)
                {
                    RG = 2.5f;
                    SN = 4f;
                }
                else if(Difficulty == difficulty_menu.DifficultyEnum.Hard)
                {
                    RG = 2f;
                    SN = 2.5f;
                }
                LevelControl.Invoke("Upgrade",3f);
                InvokeRepeating("Spawn_Regular",5f,RG);
                InvokeRepeating("Spawn_Sniper",6f,SN);                
                spawnstatus = true;
                phase = 3;
            }
            else if(Phase3Timer <= 0 && phase == 3 && EnemyAlive.Length ==0)
            {
                if(Difficulty == difficulty_menu.DifficultyEnum.Easy)
                {
                    RG = 3.5f;
                    SN = 4.5f;
                    TK = 10f;
                }
                else if(Difficulty == difficulty_menu.DifficultyEnum.Normal)
                {
                    RG = 3f;
                    SN = 4f;
                    TK = 8f;
                }
                else if(Difficulty == difficulty_menu.DifficultyEnum.Hard)
                {
                    RG = 2f;
                    SN = 2.5f;
                    TK = 6.5f;
                }
                LevelControl.Invoke("Upgrade",3f);
                InvokeRepeating("Spawn_Regular",5f,RG);
                InvokeRepeating("Spawn_Sniper",6f,SN);
                InvokeRepeating("Spawn_Tank",10f,TK);
                spawnstatus = true;
                phase = 4;
            }
            else if(Phase4Timer <= 0 && phase == 4 && EnemyAlive.Length ==0)
            {
                if(Difficulty == difficulty_menu.DifficultyEnum.Easy)
                {
                    RG = 3.5f;
                    SN = 4f;
                    TK = 10f;
                }
                else if(Difficulty == difficulty_menu.DifficultyEnum.Normal)
                {
                    RG = 3f;
                    SN = 3.5f;
                    TK = 8f;
                }   
                else if(Difficulty == difficulty_menu.DifficultyEnum.Hard)
                {
                    RG = 2f;
                    SN = 2.5f;
                    TK = 6f;
                }
                LevelControl.Invoke("Upgrade",3f);
                InvokeRepeating("Spawn_Regular",5f,RG);
                InvokeRepeating("Spawn_Sniper",6f,SN);
                InvokeRepeating("Spawn_Tank",10f,TK);
                spawnstatus = true;
                phase = 5;
            }
            else if(Phase5Timer <= 0 && phase == 5 && EnemyAlive.Length == 0)
            {
                LevelControl.Invoke("Upgrade",3f);
                Invoke("Spawn_Hexagon",5f);
                spawnstatus = true;
                phase = 6;
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
                spawnstatus = false;
            }
            else if(Phase4Timer <= 0 && phase == 4)
            {
                CancelInvoke("Spawn_Regular");
                CancelInvoke("Spawn_Sniper");
                CancelInvoke("Spawn_Tank");
                spawnstatus = false;
            }
            else if(Phase5Timer <= 0 && phase == 5)
            {
                CancelInvoke("Spawn_Regular");
                CancelInvoke("Spawn_Sniper");
                CancelInvoke("Spawn_Tank");
                spawnstatus = false;
            }
        }




    }


    
}
