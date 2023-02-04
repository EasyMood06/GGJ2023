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

    // Update is called once per frame
    void Update()
    {
        if (isActive)
            OnEquip();
    }

    //Initialize Item variables
    public virtual void OnGet()
    {
        Debug.Log("I get" + itemName);
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
