using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float speed = 5;

    [Header("Set Dynamically")]
    public int dirHeld = -1;

    private Rigidbody rigid;
    private Animator anim;

    private Vector3[] directions = new Vector3[]
        {
            Vector3.right,
            Vector3.up,
            Vector3.left,
            Vector3.down
        };

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        dirHeld = -1;
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) dirHeld = 0;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) dirHeld = 1;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) dirHeld = 2;
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) dirHeld = 3;

        Vector3 vel = Vector3.zero;
        if (dirHeld > -1) vel = directions[dirHeld];

        rigid.velocity = vel * speed;

        if (dirHeld == -1)
        {
            anim.CrossFade("PlayerIdle", 0);
            anim.speed = 0;
        }
        else
        {
            print("direction held");
            anim.CrossFade("PlayerRunning", 0);
            anim.speed = 1;
        }
    }
}
