using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillingBlanks : MonoBehaviour
{
    public Text[] texts;
    public int index;

    // Use this for initialization
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillInTheBlank(string newtext)
    {
        //string newtext = GetComponentInChildren<Text>().text;
        texts[index].text = newtext;
        index++;
    }
}
