using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancedHammer : Item
{
    public float HookFlyingSpeedChange = 10;
    public override void OnGet()
    {
        base.OnGet();
        playerController.hookFlyingSpeed += HookFlyingSpeedChange;
    }

    public override void OnEquip()
    {
        base.OnEquip();
    }
}
