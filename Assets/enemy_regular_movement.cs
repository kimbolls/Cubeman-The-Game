using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_regular_movement : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cubeman");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Transform PlayerPosition = player.GetComponent<Transform>();
        Vector2 PlayerPos = PlayerPosition.position;
        Vector2 Move = PlayerPos - rb.position;
        float moveBy = Move.x * speed;  // multiply the input with speed 
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
        

    }

    void EnemyMove()
    {

       
    }
}
