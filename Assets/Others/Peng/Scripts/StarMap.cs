using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMap: Item
{
    public override void OnGet()
    {
        base.OnGet();
        GameObject.Find("ArrowPicture").GetComponent<ArrowShowing>().enable = true;
    }

    public override void OnEquip()
    {
        base.OnEquip();
    }
}