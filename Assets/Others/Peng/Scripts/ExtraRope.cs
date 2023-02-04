using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraRope : Item
{
    public float maxDistanceChange = 5;
    public override void OnGet()
    {
        base.OnGet();
        playerController.maxDistance += maxDistanceChange;
    }

    public override void OnEquip()
    {
        base.OnEquip();
    }
}
