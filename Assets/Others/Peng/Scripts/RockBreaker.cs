using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBreaker : Item
{
    public float breakingVelocity;
    public override void OnGet()
    {
        base.OnGet();
        GameObject.Find("Player").GetComponent<BreakRock>().enable = true;
    }

    public override void OnEquip()
    {
        base.OnEquip();
    }
}
