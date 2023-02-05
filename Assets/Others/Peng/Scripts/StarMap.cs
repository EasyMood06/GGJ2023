using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMap: Item
{
    public override void OnGet()
    {
        base.OnGet();
        GameObject.Find("Main Camera").GetComponentInChildren<ArrowShowing>().enable = true;
    }

    public override void OnEquip()
    {
        base.OnEquip();
    }
}
