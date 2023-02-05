using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingFun : Item
{
    public override void OnGet()
    {
        base.OnGet();
        GameObject.Find("Main Camera").transform.GetChild(0).gameObject.SetActive(true);
    }

    public override void OnEquip()
    {
        base.OnEquip();
    }
}
