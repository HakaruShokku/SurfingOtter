using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public List<string> inventory;  //list of inventory items: words
    public Text inventoryText;  //text component, where the inventory will be displayed
    public GameObject player;   //player object

    // Use this for initialization
    void Start()
    {
        //inventory = new List<string>(); //initialize the inventory list
        int inCount = PlayerPrefs.GetInt("itemNum");
        if ((SceneManager.GetActiveScene().name != "Level1Poem") && (SceneManager.GetActiveScene().name != "Level2Poem") && (SceneManager.GetActiveScene().name != "Level2Poem"))
        {
            inventory = new List<string>();
            PlayerPrefs.DeleteKey("InventoryCount");
            for (int i = 0; i < inCount; i++)
            {
                PlayerPrefs.DeleteKey("Inventory" + i);
            }
        }
        else if ((SceneManager.GetActiveScene().name == "Level1Poem") || (SceneManager.GetActiveScene().name == "Level2Poem") || (SceneManager.GetActiveScene().name == "Level2Poem"))
        {
            for (int i = 0; i < inCount; i++)
            {
                inventory.Add(PlayerPrefs.GetString("Inventory" + i));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        string allItems = ""; //string to store all words in
        for (int i = 0; i < inventory.Count; i++)
        {
            allItems += inventory[i];
            allItems += "   ";
        }
        if (inventoryText)
        {
            inventoryText.text = allItems;
        }

    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("itemNum", inventory.Count);
        for (int i = 0; i < inventory.Count; i++)
        {
            PlayerPrefs.SetString("Inventory" + i, inventory[i]);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "WordItem")
        {
            inventory.Add(collision.gameObject.GetComponent<WordItem>().word);
            Destroy(collision.gameObject);
        }
    }
}

