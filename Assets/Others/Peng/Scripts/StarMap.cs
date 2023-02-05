using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMap: Item
{
    private void Start()
    {
        OnGet();
    }
    public override void OnGet()
    {
        base.OnGet();
        GameObject.Find("Main Camera").transform.GetChild(1).gameObject.SetActive(true);
    }

    public override void OnEquip()
    {
        base.OnEquip();
    }
}
