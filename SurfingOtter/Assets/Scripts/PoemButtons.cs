using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoemButtons : MonoBehaviour
{
    public Inventory inv;
    public GameObject buttonPrefab;
    public int xPos, yPos;

    // Use this for initialization
    void Start()
    {
        //inv = GetComponent<Inventory>();
        Debug.Log(transform.position);
        for (int i = 0; i < (inv.inventory.Count); i++)
        {
            GameObject buttonInstance = Instantiate(buttonPrefab, transform.position, Quaternion.identity, gameObject.transform);
            buttonInstance.transform.position = new Vector2(xPos, yPos);
            buttonInstance.GetComponentInChildren<Text>().text = inv.inventory[i];
            xPos += 4;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
