using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_regular_shooting : MonoBehaviour
{
    public GameObject GunPrefab;
    public GameObject player;
    public Rigidbody2D rb;
    private GameObject Gun;


    
    void Start()
    {   
        Gun = Instantiate(GunPrefab,rb.position,Quaternion.identity);
        player = GameObject.Find("Cubeman");    
        Camera cam = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {   
        
        
        
    }


    void FixedUpdate()
    {   
        StickGun();
    }

    void StickGun()
    {   
        Transform PlayerPosition = player.GetComponent<Transform>();
        Vector2 PlayerPos = PlayerPosition.position;
        Rigidbody2D Gunrb = Gun.GetComponent<Rigidbody2D>();
        Transform GunPosition = Gun.GetComponent<Transform>();
        Vector2 lookDir = PlayerPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
        Gunrb.position = rb.position;
        Gunrb.rotation = angle;
    }
}
