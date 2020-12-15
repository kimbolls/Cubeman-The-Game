using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeman_shooting : MonoBehaviour
{

    public GameObject GunPrefab;
    public Rigidbody2D rb;
    public Camera cam;


    private GameObject Gun;


    

    Vector2 mousePos;
    void Start()
    {   
        Gun = Instantiate(GunPrefab,rb.position,Quaternion.identity);
       
    }

    // Update is called once per frame
    void Update()
    {   
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }


    void FixedUpdate()
    {   
        if(GunPrefab != null)
        {
        StickGun();
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    void StickGun()
    {   
        Rigidbody2D Gunrb = Gun.GetComponent<Rigidbody2D>();
        Transform GunPosition = Gun.GetComponent<Transform>();
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
        Gunrb.position = rb.position;
        Gunrb.rotation = angle;
    }

    
}
