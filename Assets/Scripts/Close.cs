using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CloseGame", 27);
    }

    void CloseGame()
    {
        Application.Quit();
    }
}
