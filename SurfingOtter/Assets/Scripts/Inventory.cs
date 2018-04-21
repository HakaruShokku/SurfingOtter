﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public List<string> inventory;
    public Text inventoryText;
    public GameObject player;

	// Use this for initialization
	void Start () {
        inventory = new List<string>();
	}
	
	// Update is called once per frame
	void Update () {
        string allItems="";
        for(int i=0;i<inventory.Count;i++)
        {
            allItems += inventory[i];
            allItems += "   ";
        }
        inventoryText.text = allItems;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag=="WordItem")
        {
            inventory.Add(collision.gameObject.GetComponent<WordItem>().word);
            Destroy(collision.gameObject);
        }
    }
}
