using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordItem : MonoBehaviour {
    public string word;
    public Text display;

    private void Awake()
    {
        display.text = word;
    }
}
