using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public string description;
    public Sprite icon;
    public int Rarity;
    public bool isActive;
    public PlayerController playerController;

    //Initialize Item variables
    public virtual void OnGet()
    {
        Debug.Log("I get" + itemName);
        playerController = GetComponent<PlayerController>();
    }
    //Update Item Effect
    public virtual void OnEquip()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("I'm using" + itemName);
        }
    }
}
