using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FillingBlanks : MonoBehaviour
{
    public Text[] texts;
    public int index;
    public string levelName;
    public GameObject button;

    // Use this for initialization
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (index == texts.Length)
        {
            button.SetActive(true);
        }
    }

    public void FillInTheBlank(string newtext)
    {
        //string newtext = GetComponentInChildren<Text>().text;
        texts[index].text = newtext;
        index++;
    }
}
