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
        ArrowShowing a = GameObject.Find("Main Camera").transform.GetChild(1).transform.GetChild(0).GetComponentInChildren<ArrowShowing>();
        GameObject.Find("Main Camera").transform.GetChild(1).transform.GetChild(0).GetComponentInChildren<ArrowShowing>().enable = true;
    }

    public override void OnEquip()
    {
        base.OnEquip();
    }
}
