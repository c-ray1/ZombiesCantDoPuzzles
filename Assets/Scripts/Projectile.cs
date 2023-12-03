using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Set Dynamically")]
    public int damage = 1;


    void OnCollisionEnter(Collision coll)
    {
        GameObject otherGO = coll.gameObject;
        //print(otherGO.tag);
        if(otherGO.tag == "Enemies")
        {
            Enemy e = otherGO.GetComponent<Enemy>();
            e.health = e.health - damage;
            if (e.health <= 0)
            {
                Destroy(otherGO);
            }
        }
        Destroy(gameObject);
    }
}
