using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateButton : MonoBehaviour {

    public string text;
    public FillingBlanks fb;

	// Use this for initialization
	void Start () {
        text = GetComponentInChildren<Text>().text;
        fb = GameObject.Find("Inventory").GetComponent<FillingBlanks>();
    }
	
	// Update is called once per frame
	void Update () {
		//if(Input.OnMouseDown)
  //      {
  //          fb.FillInTheBlank(text);
  //      }
	}
    private void OnMouseDown()
    {
        fb.FillInTheBlank(text);
        Destroy(gameObject);
    }
}
