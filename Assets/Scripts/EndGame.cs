using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "Player")
        {
            SceneManager.LoadScene("Closing");
        }
    }
}
