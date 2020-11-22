using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hexagon : MonoBehaviour
{
    
    
    public int phase;
    public Transform[] attackspawn;
    public GameObject floatingnum;
    public GameObject hexagon_bullet;
    public float bulletForce;
    private IEnumerator coroutine;
    public float PatternTimer = 0f;
    public float max_hp = 1000f;
    public float current_hp;
    public GameObject WinMenu;
    public hexagon_ui hexagon_ui;
    public level_control level;
    void Start()
    {
        current_hp = max_hp;
        hexagon_ui.SetMaxHP(max_hp);
    }

    // Update is called once per frame
    void Update()
    {
        hexagon_ui.SetHP(current_hp);
        PatternTimer -= Time.deltaTime;
        if(PatternTimer <= 0)
        {

            RandomPattern();
        }
        if(current_hp <= 0)
        { 
            Die();
        }
    }

    void RandomPattern()
    {   
        
        int num = Random.Range(1,3);  
        int PatternLast = num;
        // cancel last repeating function --------------
        if(PatternLast == 1)
        {
            CancelInvoke("Pattern1");
        }   
        else if(PatternLast == 2)
        {
            CancelInvoke("Pattern2");
        }  
        else if(PatternLast == 3)
        {
            CancelInvoke("Pattern1");
            CancelInvoke("Pattern2");
        }
        // cancel last repeating function --------------

        if(num == 1)
        {
            InvokeRepeating("Pattern1",0f,2f);
            PatternTimer = 30f;
        }
        else if(num == 2)
        {
            InvokeRepeating("Pattern2",0f,6f);
            PatternTimer = 30f;
        }
        else if(num == 3)
        {
            InvokeRepeating("Pattern1",0f,2f);
            InvokeRepeating("Pattern2",0f,6f);
            PatternTimer = 30f;
        }


        


    }
    // 0 - 2 right | 3 - 5 left | 6 - 17 up |
    void Pattern1()
    {
        Spawner(0);
        Spawner(1);
        Spawner(2);
        coroutine = DelayedSpawner(1.0f,3);
        StartCoroutine(coroutine);
        coroutine = DelayedSpawner(1.0f,4);
        StartCoroutine(coroutine);
        coroutine = DelayedSpawner(1.0f,5);
        StartCoroutine(coroutine);
        
    }
    void Pattern2()
    {
        Spawner(6);
        float delay = 1.0f;
        coroutine = DelayedSpawner(delay,7);
        StartCoroutine(coroutine);
        coroutine = DelayedSpawner(delay += 0.3f,8);
        StartCoroutine(coroutine);
        coroutine = DelayedSpawner(delay += 0.3f,9);
        StartCoroutine(coroutine);
        coroutine = DelayedSpawner(delay += 0.3f,10);
        StartCoroutine(coroutine);
        coroutine = DelayedSpawner(delay += 0.3f,11);
        StartCoroutine(coroutine);
        coroutine = DelayedSpawner(delay += 0.3f,12);
        StartCoroutine(coroutine);
        coroutine = DelayedSpawner(delay += 0.3f,13);
        StartCoroutine(coroutine);
        coroutine = DelayedSpawner(delay += 0.3f,14);
        StartCoroutine(coroutine);
        coroutine = DelayedSpawner(delay += 0.3f,15);
        StartCoroutine(coroutine);
        coroutine = DelayedSpawner(delay += 0.3f,16);
        StartCoroutine(coroutine);
        coroutine = DelayedSpawner(delay += 0.3f,17);
        StartCoroutine(coroutine);
    }
    
    public void TakeDamage(int damage)
    {   
        current_hp -= damage;
        GameObject FloatNumbers = Instantiate(floatingnum,transform.position,Quaternion.identity);
        FloatingHandler FloatScript = FloatNumbers.GetComponent<FloatingHandler>();
        FloatScript.DisplayDamage(damage);
    } 

    void Die()
    {
        current_hp = 0;
        level.Win();
        Destroy(gameObject);
    }  
    
    // bullet spawning -------------------------------
    void Spawner(int i)
    {   
        if(i <= 2)
        {
            coroutine = SpawnRight(1.0f,i);
        }
        else if(i > 2 && i <= 5)
        {
            coroutine = SpawnLeft(1.0f,i);
        }
        else
        {
            coroutine = SpawnUp(1.0f,i);
        }

        StartCoroutine(coroutine);
    }

    IEnumerator DelayedSpawner(float waitTime,int i)
    {
        yield return new WaitForSeconds(waitTime);
        if(i <= 2)
        {
            coroutine = SpawnRight(1.0f,i);
        }
        else if(i > 2 && i <= 5)
        {
            coroutine = SpawnLeft(1.0f,i);
        }
        else
        {
            coroutine = SpawnUp(1.0f,i);
        }

        StartCoroutine(coroutine);
    }
    
    IEnumerator SpawnRight(float waitTime,int i)
    {   
        GameObject bullet = Instantiate(hexagon_bullet, attackspawn[i].position, attackspawn[i].rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        yield return new WaitForSeconds(waitTime);
        rb.AddForce(-attackspawn[i].right * bulletForce, ForceMode2D.Impulse);
    }
    
    IEnumerator SpawnLeft(float waitTime, int i)
    {
        GameObject bullet = Instantiate(hexagon_bullet, attackspawn[i].position, attackspawn[i].rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        yield return new WaitForSeconds(waitTime);
        rb.AddForce(attackspawn[i].right * bulletForce, ForceMode2D.Impulse);
    }

    IEnumerator SpawnUp(float waitTime, int i)
    {
        GameObject bullet = Instantiate(hexagon_bullet, attackspawn[i].position, attackspawn[i].rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        yield return new WaitForSeconds(waitTime);
        rb.AddForce(-attackspawn[i].right * bulletForce, ForceMode2D.Impulse);
    }
    
    //bullet spawning -------------------------------
    



 void OnCollisionEnter2D(Collision2D hitInfo)
    {
       

        cube_attributes player = hitInfo.gameObject.GetComponent<cube_attributes>();
        if(player != null)
        {
            player.TakeDamage(30);
        }
        
        
    }
}
