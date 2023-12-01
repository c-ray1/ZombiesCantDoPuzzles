using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicZombie : Enemy
{
    public Transform player;
    private Vector2 movement;

    [Header("Set in Inspector: BasicZombie")]
    public int speed = 2;
    public float timeThinkMin = 1f;
    public float timeThinkMax = 4f;

    [Header("Set Dynamically: BasicZombie")]
    public int facing = 0;
    public float timeNextDecision = 0;


    void Update()
    {
        Vector3 direction = player.position - transform.position;
        print(direction.magnitude);
        if (direction.magnitude <= 9)
        {
            direction.Normalize();
            movement = direction;
        }
        else
        {
            print("inside");
            if (Time.time >= timeNextDecision)
            {
                DecideDecision();
            }

            rigid.velocity = directions[facing] * speed;
        }
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rigid.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void DecideDecision()
    {
        facing = Random.Range(0, 4);
        timeNextDecision = Time.time + Random.Range(timeThinkMin, timeThinkMax);
    }
}
