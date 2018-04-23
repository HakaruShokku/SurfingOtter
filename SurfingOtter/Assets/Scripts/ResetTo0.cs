using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTo0 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Lives", 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
