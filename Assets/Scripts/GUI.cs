using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GUI : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Player player;
    public Text healthDisplay;
    public Text keyDisplay;

    void Start()
    {
        Transform keyPanel = transform.Find("Keys");
        keyDisplay = keyPanel.GetComponent<Text>();
        Transform healthPanel = transform.Find("Health");
        healthDisplay = healthPanel.GetComponent<Text>();
    }

    void Update()
    {
        keyDisplay.text = "Keys: " + player.numKeys.ToString();
        healthDisplay.text = "Health: " + player.health.ToString();
    }

}
