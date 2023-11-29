using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    

    [Header("Set Dynamically")]
    public float camZ;
    public GameObject Player;

    // Start is called before the first frame update
    void Awake()
    {
        camZ = this.transform.position.z;
    }

    void FixedUpdate()
    {
        if (Player == null) return;

        Vector3 destination = Player.transform.position;
        destination.z = camZ;
        transform.position = destination;
    }
}
