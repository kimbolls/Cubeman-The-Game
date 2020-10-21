using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun1_shooting : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform Firepoint;
    public GameObject BulletPrefab;

    public float bulletForce;

    float attackrate = 5f;
    float nextAttacktime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttacktime)
        {
        if(Input.GetButton("Fire1") && Time.timeScale != 0f ) // pressing Mouse 1 will trigger this
        {
            Shoot();
            nextAttacktime = Time.time + 1f/ attackrate;
        }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, Firepoint.position, Firepoint.rotation);  // spawns bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();  // set rigidbody of the bullet
        rb.AddForce(Firepoint.right * bulletForce, ForceMode2D.Impulse);  //add force to the bullet
    }
}
