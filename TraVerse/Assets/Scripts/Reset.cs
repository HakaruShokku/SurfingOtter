using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Lives", 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
