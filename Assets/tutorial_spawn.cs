using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_spawn : MonoBehaviour
{
    public GameObject RegularEnemy;
    public GameObject SniperEnemy;
    public GameObject TankEnemy;

    public Transform SpawnPoint;
    
    public void SpawnRegular()
    {
        GameObject enemy_regular_spawn = Instantiate(RegularEnemy,SpawnPoint.position,Quaternion.identity);
    }

    public void SpawnSniper()
    {
        GameObject enemy_sniper_spawn = Instantiate(SniperEnemy,SpawnPoint.position,Quaternion.identity);
    }
    public void SpawnTank()
    {
        GameObject enemy_tank_spawn = Instantiate(TankEnemy,SpawnPoint.position,Quaternion.identity);
    }
}
