using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedWordsCheck : MonoBehaviour {

    public GameObject triggerCol;
    public Text wordsNeed;
	// Use this for initialization
	void Start () {
        wordsNeed.enabled = true;
        triggerCol.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
