using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Queue<string> dialouge;
    public Text dialougeText;

    // Start is called before the first frame update
    void Start()
    {
        dialouge = new Queue<string>();

    }

    public void StartText(Dialougue text)
    {
        Debug.Log("Starting text");

        dialouge.Clear();

        foreach(string sentence in text.sentences)
        {
            dialouge.Enqueue(sentence);
        }

        Invoke("DisplayNextSentence", 2);
    }

    public void DisplayNextSentence()
    {
        if (dialouge.Count == 0)
        {
            EndDialouge();
            return;
        }

        string sentence = dialouge.Dequeue();
        dialougeText.text = sentence;
        Invoke("DisplayNextSentence", 5);

    }

    public void EndDialouge()
    {
        Debug.Log("End Dialouge");
    }
}
