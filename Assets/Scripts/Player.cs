using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public enum eMode { idle, move, knockback }

    [Header("Set in Inspector")]
    public float speed = 5;
    public float health = 10;
    public float knockbackSpeed = 10;
    public float knockbackDuration = 0.25f;
    public float invincibleDuration = 0.5f;
    public float gameRestartDelay = 2f;

    [Header("Set Dynamically")]
    public int dirHeld = -1;
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;
    public bool invincible = false;
    public eMode mode = eMode.idle;

    private Rigidbody rigid;
    private Animator anim;
    private SpriteRenderer sRend;

    private float knockbackDone = 0;
    private float invincibleDone = 0;
    private Vector3 knockbackVel;

    private Vector3[] directions = new Vector3[]
        {
            Vector3.right,
            Vector3.up,
            Vector3.left,
            Vector3.down
        };

    void Awake()
    {
        sRend = GetComponent<SpriteRenderer>();
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
        Vector3 offset = Vector3.zero;
        if (dirHeld > -1) vel = directions[dirHeld];

        rigid.velocity = vel * speed;

        if (dirHeld == -1)
        {
            mode = eMode.idle;
            anim.CrossFade("PlayerIdle", 0);
            anim.speed = 0;
        }
        else
        {
            mode = eMode.move;
            //print("direction held");
            anim.CrossFade("PlayerRunning", 0);
            anim.speed = 1;
        }
        
        switch (dirHeld)
        {
            case -1:
                offset = new Vector3(1, 0, 0);
                break;
            case 0: 
                offset = new Vector3(1, 0, 0);
                break;
            case 1:
                offset = new Vector3(0, 1, 0);
                break;
            case 2:
                offset = new Vector3(-1, 0, 0);
                break;
            case 3:
                offset = new Vector3(0, -1, 0);
                break;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TempFire(vel, offset);
        }

        if (invincible && Time.time > invincibleDone) invincible = false;
        sRend.color = invincible ? Color.red : Color.white;
        if(mode == eMode.knockback)
        {
            rigid.velocity = knockbackVel;
            if (Time.time < knockbackDone) return;
        }
    }

    void TempFire(Vector3 vel, Vector3 offset)
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position + offset;
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        if(vel == Vector3.zero)
        {
            vel = Vector3.right;
        }
        rigidB.velocity = vel * projectileSpeed;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject otherGO = coll.gameObject;
        if(otherGO.tag == "Enemies")
        {
            if (invincible) return;
            Enemy e = otherGO.GetComponent<Enemy>();
            health = health - e.damage;
            invincible = true;
            invincibleDone = Time.time + knockbackDuration;
            DamageEffect def = otherGO.GetComponent<DamageEffect>();
            if (def.knockback)
            {
                Vector3 delta = transform.position - coll.transform.position;
                if(Mathf.Abs(delta.x) >= Mathf.Abs(delta.y))
                {
                    delta.x = (delta.x > 0) ? 1 : -1;
                    delta.y = 0;
                }
                else
                {
                    delta.x = 0;
                    delta.y = (delta.y > 0) ? 1 : -1;
                }
                knockbackVel = delta * knockbackSpeed;
                rigid.velocity = knockbackVel;

                mode = eMode.knockback;
                knockbackDone = Time.time + knockbackDuration;
            }
            if(health <= 0)
            {
                BasicZombie BZ = otherGO.GetComponent<BasicZombie>();
                BZ.speed = 0;
                Invoke(nameof(Restart), gameRestartDelay);
            }
        }
    }

    void Restart()
    {
        print("restart");
        Destroy(gameObject);
        SceneManager.LoadScene("LevelOne");
    }
}
