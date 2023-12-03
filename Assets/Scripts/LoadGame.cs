using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadScene", 35);
    }

    void LoadScene()
    {
        SceneManager.LoadScene("LevelOne");
    }
}
