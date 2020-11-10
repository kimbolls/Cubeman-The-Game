using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_sniper_shooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Firepoint;
    public GameObject BulletPrefab;

    public float bulletForce;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot",1f,3f);
        InvokeRepeating("Shoot",1.2f,3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, Firepoint.position, Firepoint.rotation);  // spawns bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();  // set rigidbody of the bullet
        rb.AddForce(Firepoint.right * bulletForce, ForceMode2D.Impulse);  //add force to the bullet
    }
}
