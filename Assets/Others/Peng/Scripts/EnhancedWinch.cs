using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancedWinch:Item
{
    public float hookReturningSpeedChange = 5;
    public override void OnGet()
    {
        base.OnGet();
        playerController.hookReturningSpeed += hookReturningSpeedChange;
    }

    public override void OnEquip()
    {
        base.OnEquip();
    }
}
