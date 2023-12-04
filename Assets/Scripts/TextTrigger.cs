using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public Dialougue text;

    void Start()
    {
        DialougeManager();
    }

    public void DialougeManager()
    {
        //print(text);
        FindObjectOfType<TextManager>().StartText(text);
    }
}
