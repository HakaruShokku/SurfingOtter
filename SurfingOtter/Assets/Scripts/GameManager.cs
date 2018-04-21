using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private SpawningBlocks sb;
    public Text pause;
	// Use this for initialization
	void Start () {
        sb = GetComponent<SpawningBlocks>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale=(Time.timeScale==0)?1:0;
            sb.enabled = !sb.enabled;
            pause.enabled = !pause.enabled;
        }
	}
}
