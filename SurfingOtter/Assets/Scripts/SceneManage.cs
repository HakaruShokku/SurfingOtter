using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour {

	// Use this for initialization
    public void LoadLevel(string valueName)
    {
        SceneManager.LoadScene(valueName);
    }
	void Start () {
		
	}

    //public void Quit()
    //{
        
    //}
    // Update is called once per frame
    void Update () {
		
	}
}
